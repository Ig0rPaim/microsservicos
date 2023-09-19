using AutoMapper;
using LoginAPI.Data;
using LoginAPI.Exceptions;
using LoginAPI.Models;
using LoginAPI.ValuesObjects;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LoginAPI.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly AplicationDbContextUser _dbUser;
        private readonly UserManager<IdentityUser> _userManager;
        private IMapper _mapper;
        private readonly MappingProfile _mappingProfile;

        public UserRepository(AplicationDbContextUser dbUser, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _dbUser = dbUser;
            _mapper = mapper;
        }

        public IResult Create(UserVO userVO)
        {
            UserModel userModel = _mapper.Map<UserModel>(userVO);
            userModel.DataCadastro = DateTime.Now;
            //_dbUser.User.Add(User);
            //_dbUser.SaveChanges();
            //return _mapper.Map<UserVO>(User);
            var user = new IdentityUser { UserName = userModel.Email, Email = userModel.Email, PhoneNumber = userModel.Phone };
            var result = _userManager.CreateAsync(user, userModel.Password).Result;
            if(!result.Succeeded) { return Results.BadRequest(result.Errors.First()); }
            var userClaims = new List<Claim>
            {
                new Claim("Name", userModel.Nome),
                new Claim ("Password", userModel.Password),
                new Claim ("DataCadastro", userModel.DataCadastro.ToString()),
            };
            var claimResult =
                _userManager.AddClaimsAsync(user, userClaims).Result;

            return Results.Created($"User/{user.Id}", user.Id);
        }

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        UserModel User = _dbUser.User.FirstOrDefault(x => x.Id == id) ?? new UserModel();
        //        if (User.Id <= 0) { return false; }
        //        _dbUser.User.Remove(User);
        //        _dbUser.SaveChanges();
        //        return true;
        //    }
        //    catch (GenericException)
        //    {
        //        throw new GenericException("Usuário não encontrado. Erro na Busca por Id");
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        public IResult GetAll()
        {
            //List<UserModel> User = _dbUser.User.ToList();
            //return _mapper.Map<List<UserVO>>(User);
            var users = _userManager.Users.ToList();
            return Results.Ok(_mappingProfile.Map<List<UserVO>>(users));
        }

        //public UserVO GetById(int id)
        //{
        //    try
        //    {

        //        UserModel User = _dbUser.User.FirstOrDefault(x => x.Id == id) ?? new UserModel();
        //        return _mapper.Map<UserVO>(User);
        //    }
        //    catch (GenericException)
        //    {

        //        throw new GenericException("Usuário não encontrado. Erro na Busca por Id");
        //    }
        //}

        //public UserVO Update(UserVO userVO, int Id)
        //{
        //    try
        //    {
        //        UserModel UserUpdate = _dbUser.User.FirstOrDefault(x => x.Id == Id) ?? throw new GenericException("Nenhum resultado encontrado");
        //        UserModel User = _mapper.Map<UserModel>(userVO);
        //        UserUpdate.Nome = User.Nome;
        //        UserUpdate.Email = User.Email;
        //        UserUpdate.Password = User.Password;
        //        UserUpdate.Phone = User.Phone;
        //        UserUpdate.DataAtualizacao = DateTime.Now;
        //        _dbUser.User.Update(UserUpdate);
        //        _dbUser.SaveChanges();
        //        return _mapper.Map<UserVO>(UserUpdate);
        //    }
        //    catch (GenericException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;

        //    }
        //    catch(Exception e) 
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        // }
    }
}
