using Domain.Contracts;
using Domain.Entities.WebRequestModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartSevice )
        {
            _cartService = cartSevice;
        }
        [HttpPost]
        [Route("register-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> RegisterOrder([FromBody] RegisterOrderModel registerOrderModel)
        {
           var registerorderResult = _cartService.CreateOrder(registerOrderModel.OrderItem, registerOrderModel.userNationalCode);
            if (registerorderResult.Result)
            {
                return Ok(registerorderResult);
            }
            else
            {
                return BadRequest(registerorderResult);
            }
        }
    }
}
