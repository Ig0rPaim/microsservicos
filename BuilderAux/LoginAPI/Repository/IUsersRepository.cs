using LoginAPI.ValuesObjects;

namespace LoginAPI.Repository
{
    public interface IUsersRepository
    {
        IResult GetAll();
        //UserVO GetById(int id);
        IResult Create(UserVO userVO);
        //UserVO Update(UserVO userVO, int Id);
        //bool Delete(int id);
    }
}
