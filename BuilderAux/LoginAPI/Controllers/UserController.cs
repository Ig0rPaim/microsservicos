using LoginAPI.Models;
using LoginAPI.Repository;
using LoginAPI.ValuesObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(Repository));
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var User = _usersRepository.GetAll();
            if (User == null) { return NotFound(); }
            return Ok(User);
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var User = _usersRepository.GetById(Id);
            if (User.Id <= 0) { return NotFound(); }
            return Ok(User);
        }

        [HttpPost]
        public ActionResult Create([FromBody] UserVO UserVO)
        {
            if (UserVO == null) { return BadRequest(); }
            var User = _usersRepository.Create(UserVO);
            return Ok(User);
        }

        [HttpPut]
        public ActionResult Update([FromBody] UserVO UserVO)
        {
            if (UserVO == null) { return BadRequest(); }
            var User = _usersRepository.Update(UserVO);
            return Ok(User);
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var Status = _usersRepository.Delete(Id);
            if (User == null) { return BadRequest();}
            return Ok(Status);
        }
    }
}
