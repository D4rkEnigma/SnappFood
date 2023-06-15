using Domain.Entities;
using Domain.Entities.ApiDtos;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IResturantService
    {
        ServiceResult<IEnumerable<Restaurant>> GetRestueantList();
        ServiceResult<Restaurant> GetRestueantById(string id);
        ServiceResult<Restaurant> RegisterResturant(Restaurant restaurant);
        ServiceResult<IEnumerable<MenuItem>> GetResturantMenu(string resturantId);
        ServiceResult<Restaurant> LoginResturant(string username, string password);
        ServiceResult<bool> AddMenuItem(AddMenuItemModel menuItemModel);
        ServiceResult<IEnumerable<ResturantOrderModel>> GetResturantOrdersByRestaurantID(string restaurantID);
        ServiceResult<bool> MarkCartItemsDeliveredByCartID(string cartID);
    }
}
