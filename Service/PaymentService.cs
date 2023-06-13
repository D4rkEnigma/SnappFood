using Domain.Contracts;
using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private IRestaurantRepository _restaurantRepository;
        public PaymentService(IUserRepository userepository,IMenuItemRepository menuitemRepository,IRestaurantRepository resturantRepository)
        {
            _userRepository= userepository;
            _menuItemRepository= menuitemRepository;
            _restaurantRepository= resturantRepository;
        }
        public ServiceResult<bool> Pay(string userNationalCode,Cart order )
        {
            var price = order.Items.Sum( x => (x.Price) * x.Count);
            var user = _userRepository.GetUserByNationalCode(userNationalCode);
            if (user.Balance >= price)
            {
                user.Balance -= price;
                _userRepository.EditUserByNationalCode(userNationalCode, user);
                foreach (var item in order.Items)
                {
                    var resturanId = _menuItemRepository.GetMenuItemByID(item.MenuItemID).RestaurantID;
                    var resturant = _restaurantRepository.GetRestaurantById(resturanId);
                    resturant.Balance += item.Price * item.Count;
                    _restaurantRepository.EditRestaurantByName(resturant.Name, resturant);
                }
                return new ServiceResult<bool>()
                {
                    Result = true,

                };
            }
            else
            {
                return new ServiceResult<bool>()
                {
                    Result = false,
                    Message = "Balance Is Not Enough"
                    
                };
            }
        }
    }
}
