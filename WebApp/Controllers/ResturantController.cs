using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.ApiDtos;
using Domain.Entities.WebRequestModels;
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
        public ActionResult<IEnumerable<Restaurant>> GetAllResturant() 
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
        public ActionResult<Restaurant> ResturantRegister([FromBody] Restaurant resturant)
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
        public ActionResult<Restaurant> GetResturant(string id)
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

        [HttpGet("{id}/get-menu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MenuItem>> GetRestaurantMenu(string id) 
        {
            var resturantMenu = _resturantService.GetResturantMenu(id);
            if (resturantMenu.IsSuccees)
            {
                return Ok(resturantMenu.Result);
            }
            else
            {
                return BadRequest(resturantMenu?.Message);
            }
        }
        [HttpGet("{id}/get-restaurant-orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ResturantOrderModel>> GetResturantOrdersByRestaurantID(string id)
        {
            var resturantMenu = _resturantService.GetResturantOrdersByRestaurantID(id);
            if (resturantMenu.IsSuccees)
            {
                return Ok(resturantMenu.Result);
            }
            else
            {
                return BadRequest(resturantMenu?.Message);
            }
        }
        [HttpPost("order-delivered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Restaurant> CartItemsDeliveryByCartID([FromBody] string cartID)
        {
            var result = _resturantService.MarkCartItemsDeliveredByCartID(cartID);
            if (result.IsSuccees)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result?.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Restaurant> LoginRestaurant([FromBody] ResturantLoginModel resturantLoginModel)
        {
            var result = _resturantService.LoginResturant(resturantLoginModel.userName, resturantLoginModel.password);
            if(result.IsSuccees)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result?.Message);
            }
        }

        [HttpPost("add-menuitem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Restaurant> AddMenuItemForResturant([FromBody] AddMenuItemModel menuItemModel)
        {
            var result = _resturantService.AddMenuItem(menuItemModel);
            if(result.IsSuccees)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result?.Message);
            }
        }
        //[HttpGet("show-resturant-orders/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<IEnumerable<ResturantOredrModel>> ShowResturantOrders(string resturantID)
        //{
        //    result;
        //}
    }
}
