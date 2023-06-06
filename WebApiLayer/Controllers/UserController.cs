using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuser/{id:int}",Name ="getuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> GetUser(int id)
        {
            if (_userService.GetUser(id).Result != null) 
            {
                return Ok(_userService.GetUser(id).Result);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPost("registeruser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> RegisterUser([FromBody]User user)
        {
            
            var result = _userService.RegisterUser(user);
            if (result.IsSuccees)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(user);
            }
            
            
        }



    }
}
