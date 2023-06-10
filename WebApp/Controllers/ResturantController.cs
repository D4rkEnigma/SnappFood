using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _resturantService;
        public ResturantController(IResturantService resturantService) 
        {
            _resturantService= resturantService;
        }
        [HttpGet("resturants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllResturant() 
        { 
            if (_resturantService.GetRestueantList().IsSuccees)
            {
                return Ok(_resturantService.GetRestueantList().Result);
            }
            else
            {
                return BadRequest(_resturantService.GetRestueantList().Message);
            }
        }
        [HttpPost("resturant-register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ResturantRegister([FromBody] Restaurant resturant)
        {
            var result = _resturantService.RegisterResturant(resturant);
            if (result.IsSuccees)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetResturant(string id)
        {
            var resturant = _resturantService.GetRestueantById(id);
            if (resturant.IsSuccees)
            {
                return Ok(resturant.Result);
            }
            else
            {
                return BadRequest(resturant.Message);
            }
        }

    }
}
