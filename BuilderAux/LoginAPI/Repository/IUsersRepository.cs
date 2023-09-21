using LoginAPI.ValuesObjects;

namespace LoginAPI.Repository
{
    public interface IUsersRepository
    {
        IResult GetAll();
        IResult GetByEmail(string Email);
        IResult Create(UserVOIn userVO);
        Task<IResult> UpdateAsync(UserVOIn userVOIn, string Email);
        bool Delete(string Email);
    }
}
