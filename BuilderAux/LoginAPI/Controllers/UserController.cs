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

        //[HttpGet("GetById/{Id}")]
        //public ActionResult GetById(int Id)
        //{
        //    var User = _usersRepository.GetById(Id);
        //    if (User.Id <= 0) { return NotFound(); }
        //    return Ok(User);
        //}

        [HttpPost("Create")]
        public ActionResult Create([FromBody] UserVO UserVO)
        {

            if (UserVO == null) { return BadRequest("Entidade Vazia"); }
            if (!UserVO.IsValid) { return BadRequest(UserVO.Notifications); }

            var User = _usersRepository.Create(UserVO);
            return Ok(User);
        }

        //[HttpPut("Update/{Id}")]
        //public ActionResult Update([FromBody] UserVO UserVO, int Id)
        //{
        //    if (UserVO == null) { return BadRequest("Entidade Vazia"); }
        //    if (!UserVO.IsValid) { return BadRequest(UserVO.Notifications); }
        //    var User = _usersRepository.Update(UserVO, Id);
        //    if(User == null) { return BadRequest("Usuario não encontrado"); }
        //    return Ok(User);
        //}

        //[HttpDelete("Delete/{Id}")]
        //public ActionResult Delete(int Id)
        //{
        //    var Status = _usersRepository.Delete(Id);
        //    if (Status == false) { return BadRequest();}
        //    return Ok(Status);
        //}
    }
}
