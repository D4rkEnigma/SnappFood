using Domain.Contracts;
using Domain.Entities;
using Domain.ServiceResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApp.Controllers
{
   
     [ApiController]
     [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public  UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public User GetUser(int id)
        {
            return _userService.GetUser(id).Result;
        }


    }
}
