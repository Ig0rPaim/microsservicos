using AutoMapper;
using LoginAPI.Data;
using LoginAPI.Exceptions;
using LoginAPI.Models;
using LoginAPI.ValuesObjects;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using LoginAPI.Config;

namespace LoginAPI.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly AplicationDbContextUser _dbUser;
        private readonly UserManager<IdentityUser> _userManager;
        private IMapper _mapper;
        //private readonly MappingProfile _mappingProfile;

        public UserRepository(AplicationDbContextUser dbUser, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _dbUser = dbUser;
            _mapper = mapper;
        }

        public IResult Create(UserVOIn userVOIn)
        {
            UserModel userModel = _mapper.Map<UserModel>(userVOIn);
            userModel.DataCadastro = DateTime.Now;
            var userVerification = _userManager.FindByEmailAsync(userModel.Email).Result;
            if(userVerification != null) { throw new GenericException("O Email ja foi Cadastrado"); }
            //_dbUser.User.Add(User);
            //_dbUser.SaveChanges();
            //return _mapper.Map<UserVO>(User);
            var user = new IdentityUser { UserName = userModel.Email, Email = userModel.Email, PhoneNumber = userModel.Phone };
            var result = _userManager.CreateAsync(user, userModel.Password).Result;
            if(!result.Succeeded) { return Results.BadRequest(result.Errors.First()); }
            var userClaims = new List<Claim>
            {
                new Claim("Name", userModel.Nome),
                new Claim ("DataAtualizacao", string.Empty),
                new Claim ("DataCadastro", userModel.DataCadastro.ToString()),
            };
            var claimResult =
                _userManager.AddClaimsAsync(user, userClaims).Result;

            return Results.Created($"User/{claimResult}", claimResult);
        }

        public bool Delete(string Email)
        {
                //UserModel User = _dbUser.User.FirstOrDefault(x => x.Id == id) ?? new UserModel();
                //if (User.Id <= 0) { return false; }
                //_dbUser.User.Remove(User);
                //_dbUser.SaveChanges();
                //return true;
                var user = _userManager.FindByEmailAsync(Email).Result;
                if (user != null)
                {
                    var result = _userManager.DeleteAsync(user).Result;
                    if (!result.Succeeded) { throw new GenericException("Erro ao deletar Usuário"); }
                    else { return true; }
                }
                else { throw new GenericException("Usuário não encontrado"); }
        }

        public IResult GetAll()
        {
            //List<UserModel> User = _dbUser.User.ToList();
            //return _mapper.Map<List<UserVO>>(User);
            var users = _userManager.Users.ToList();
            var usersVOOut = new List<UserVOOut>();
            foreach (var user in users) 
            {
                var claim = _userManager.GetClaimsAsync(user).Result;
                var claimName = claim.FirstOrDefault(claim =>  claim.Type == "Name");
                var userName = claimName != null? claimName.Value : string.Empty;
                usersVOOut.Add(new UserVOOut(userName, user.Email, user.PhoneNumber)); 
            }
            return Results.Ok(usersVOOut);
        }

        public IResult GetByEmail(string Email)
        {
            //try
            //{

            //    UserModel User = _dbUser.User.FirstOrDefault(x => x.Id == id) ?? new UserModel();
            //    return _mapper.Map<UserVO>(User);
            //}
            //catch (GenericException)
            //{

            //    throw new GenericException("Usuário não encontrado. Erro na Busca por Id");
            //}
            var user = _userManager.FindByEmailAsync(Email).Result;
            UserVOOut usersVOOut;
                if (user != null)
                {
                var claim = _userManager.GetClaimsAsync(user).Result;
                var claimName = claim.FirstOrDefault(claim => claim.Type == "Name");
                var userName = claimName != null ? claimName.Value : string.Empty;
                usersVOOut = new UserVOOut(userName, user.Email, user.PhoneNumber);
                return Results.Ok(usersVOOut);
                }
                else { throw new GenericException("Usuário não encontrado"); }

        }

        public UserManager<IdentityUser> Get_userManager()
        {
            return _userManager;
        }

        public async Task<IResult> UpdateAsync(UserVOIn userVOIn, string Email)
        {
            try
            {
                UserModel userModel = _mapper.Map<UserModel>(userVOIn);
                userModel.DataAtualizacao = DateTime.Now;
                IdentityUser user = _userManager.FindByEmailAsync(Email).Result;
                if (user == null) { throw new GenericException("Usuario não encontrado"); }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user); // // //

                user.UserName = userVOIn.Email;
                user.Email = userVOIn.Email;
                user.PhoneNumber = userVOIn.Phone;
                var claim = _userManager.GetClaimsAsync(user).Result;
                List<Claim> claimsToRemove = new List<Claim>();
                var existingClaimName = claim.FirstOrDefault(c => c.Type == "Name");
                var existingClaimUpdate = claim.FirstOrDefault(c => c.Type == "DataAtualizacao");
                if (existingClaimName != null && existingClaimUpdate != null)
                {
                    UpdateClaim(claimsToRemove, existingClaimName, existingClaimUpdate, user, userModel);
                    //await _userManager.UpdateAsync(user);
                }
                var result = await _userManager.ResetPasswordAsync(user, token, userModel.Password); //
                if (!result.Succeeded) { throw new GenericException("Erro ao atualizar usuário"); }//
                await _userManager.UpdateAsync(user);
                return Results.Ok(userModel.Nome);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            





        }

        private IResult BadRequest(string message)
        {
            throw new NotImplementedException();
        }

        private async void UpdateClaim(List<Claim> claimsToRemove, Claim existingClaimName, Claim existingClaimUpdate, IdentityUser user, UserModel userModel)
        {
            for (int i = 0; i < 2; i++)
            {
                claimsToRemove.Add(existingClaimName);
                claimsToRemove.Add(existingClaimUpdate);
            }
            await _userManager.RemoveClaimsAsync(user, claimsToRemove);
            await _userManager.AddClaimAsync(user, new Claim("Name", userModel.Nome));
            try
            {
                await _userManager.AddClaimAsync(user, new Claim("DataAtualizacao", userModel.DataAtualizacao.ToString()));
            }
            catch (ArgumentNullException e)
            {

                throw new ArgumentNullException("Ops tivemos um erro ao atualizar, tente novamente");
            }
            catch (Exception e)
            {
                throw new Exception($"Erro inesperado: {e.Message}");
            }
        }

   
    }
}
