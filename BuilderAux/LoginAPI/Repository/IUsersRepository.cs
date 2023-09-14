using LoginAPI.ValuesObjects;

namespace LoginAPI.Repository
{
    public interface IUsersRepository
    {
        List<UserVO> GetAll();
        UserVO GetById(int id);
        UserVO Create(UserVO userVO);
        UserVO Update(UserVO userVO);
        bool Delete(int id);
    }
}
