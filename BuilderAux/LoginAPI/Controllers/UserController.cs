using LoginAPI.Exceptions;
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
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var User = _usersRepository.GetAll();
            if (User == null) { return NotFound(); }
            return Ok(User);
        }

        [HttpGet("GetByEmail/{Email}")]
        public ActionResult GetById(string Email)
        {
            try
            {
                var User = _usersRepository.GetByEmail(Email);
                //if (User.Id <= 0) { return NotFound(); }
                return Ok(User);
            }
            catch (GenericException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] UserVOIn UserVO)
        {

            if (UserVO == null) { return BadRequest("Entidade Vazia"); }
            if (!UserVO.IsValid) { return BadRequest(UserVO.Notifications); }

            var User = _usersRepository.Create(UserVO);
            return Ok(User);
        }

        [HttpPut("Update/{Email}")]
        public ActionResult Update([FromBody] UserVOIn UserVOIn, string Email)
        {
            try
            {
                if (UserVOIn == null) { return BadRequest("Entidade Vazia"); }
                if (!UserVOIn.IsValid) { return BadRequest(UserVOIn.Notifications); }
                var User = _usersRepository.UpdateAsync(UserVOIn, Email);
                //if (User == null) { return BadRequest("Usuario não encontrado"); }
                return Ok(User);
            }
            catch (GenericException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{Email}")]
        public ActionResult Delete(string Email)
        {
            try
            {
                var Status = _usersRepository.Delete(Email);
                //if (Status == false) { return BadRequest(); }
                return Ok(Status);
            }
            catch (GenericException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
