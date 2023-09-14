﻿using AutoMapper;
using LoginAPI.Data;
using LoginAPI.Exceptions;
using LoginAPI.Models;
using LoginAPI.ValuesObjects;

namespace LoginAPI.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly AplicationDbContextUser _dbUser;
        private IMapper _mapper;

        public UserRepository(AplicationDbContextUser dbUser, IMapper mapper)
        {
            _dbUser = dbUser;
            _mapper = mapper;
        }

        public UserVO Create(UserVO userVO)
        {
            UserModel User = _mapper.Map<UserModel>(userVO);
            User.DataCadastro = DateTime.Now;
            _dbUser.User.Add(User);
            _dbUser.SaveChanges();
            return _mapper.Map<UserVO>(User);
        }

        public bool Delete(int id)
        {
            try
            {
                UserModel User = _dbUser.User.FirstOrDefault(x => x.Id == id) ?? new UserModel();
                if (User.Id <= 0) { return false; }
                _dbUser.User.Remove(User);
                _dbUser.SaveChanges();
                return true;
            }
            catch (GenericException)
            {
                throw new GenericException("Usuário não encontrado. Erro na Busca por Id");
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<UserVO> GetAll()
        {
            List<UserModel> User = _dbUser.User.ToList();
            return _mapper.Map<List<UserVO>>(User);
        }

        public UserVO GetById(int id)
        {
            try
            {

                UserModel User = _dbUser.User.FirstOrDefault(x => x.Id == id) ?? new UserModel();
                return _mapper.Map<UserVO>(User);
            }
            catch (GenericException)
            {

                throw new GenericException("Usuário não encontrado. Erro na Busca por Id");
            }
        }

        public UserVO Update(UserVO userVO)
        {
            UserModel User = _mapper.Map<UserModel>(userVO);
            User.DataAtualizacao = DateTime.Now;
            _dbUser.User.Update(User);
            _dbUser.SaveChanges();
            return _mapper.Map<UserVO>(User);
        }
    }
}
