using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.ApiDtos;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ResturantService : IResturantService
    {
        private readonly IRestaurantRepository _resturantRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        public ResturantService(IRestaurantRepository resturantRepository, IMenuItemRepository menuItemRepository, ICartItemRepository cartItemrepository,
            IUserRepository userRepository, ICartRepository cartRepository)
        {
            _resturantRepository = resturantRepository;
            _menuItemRepository = menuItemRepository;
            _cartItemRepository = cartItemrepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
        }
        public ServiceResult<IEnumerable<Restaurant>> GetRestueantList()
        {
            var resturantList = new ServiceResult<IEnumerable<Restaurant>>();
            if (_resturantRepository.GetRestaurantsList() != null)
            {
                resturantList.Result = _resturantRepository.GetRestaurantsList();
                resturantList.IsSuccees = true;
            }
            else
            {
                resturantList.IsSuccees = false;
                resturantList.Message = "No Resturant Found";

            }
            return resturantList;
        }

        public ServiceResult<Restaurant> GetRestueantById(string id)
        {
            var resturant = new ServiceResult<Restaurant>();
            if (_resturantRepository.GetRestaurantById(id) != null)
            {
                resturant.Result = _resturantRepository.GetRestaurantById(id);
                resturant.IsSuccees = true;
            }
            else
            {
                resturant.IsSuccees = false;
                resturant.Message = "No Resturant Found";

            }
            return resturant;
        }

        public ServiceResult<Restaurant> RegisterResturant(Restaurant restaurant)
        {
            var result = new ServiceResult<Restaurant>();
            if (restaurant == null)
            {
                result.IsSuccees = false;
                result.Message = "Null Request";
            }
            else
            {
                restaurant.RestaurantID = Guid.NewGuid().ToString();
                _resturantRepository.AddRestaurant(restaurant);
                result.IsSuccees = true;
                result.Result = restaurant;
                result.Message = "Successfully Register";
            }
            return result;
        }

        public ServiceResult<IEnumerable<MenuItem>> GetResturantMenu(string resturantId)
        {
            if (_resturantRepository.GetRestaurantById(resturantId) != null)
            {
                var result = _menuItemRepository.GetMenuItemsListByRestaurantID(resturantId);
                return new ServiceResult<IEnumerable<MenuItem>>()
                {
                    IsSuccees = true,
                    Result = result,
                };
            }
            else
            {
                return new ServiceResult<IEnumerable<MenuItem>>()
                {
                    IsSuccees = false,
                    Message = "Resturant Not Found",
                };
            }


        }

        public ServiceResult<Restaurant> LoginResturant(string username, string password)
        {
            Restaurant _restaurant = _resturantRepository.GetRestaurantById(username);
            if (_restaurant == null)
            {
                return new ServiceResult<Restaurant>("Restaurant Not Exist")
                {
                    IsSuccees = false,

                };
            }
            else if (password != _restaurant.Password)
            {
                return new ServiceResult<Restaurant>("Password Is Incorrect")
                {
                    IsSuccees = false,
                };
            }
            else
            {
                return new ServiceResult<Restaurant>("Successfully login")
                {
                    IsSuccees = true,
                    Result = _restaurant,
                };
            }
        }

        public ServiceResult<bool> AddMenuItem(AddMenuItemModel menuItemModel)
        {
            if (menuItemModel != null)
            {
                var menuItem = new MenuItem(Guid.NewGuid().ToString(),
                menuItemModel.ResturantID,
                menuItemModel.foodName,
                menuItemModel.price,
                menuItemModel.cooockingTime);
                _menuItemRepository.AddMenuItem(menuItem);
                return new ServiceResult<bool> { IsSuccees = true };

            }
            else
            {
                return new ServiceResult<bool>() { IsSuccees = false, Message = "Null Request" };

            }
        }
        public ServiceResult<bool> MarkCartItemsDeliveredByCartID(string cartID)
        {
            try
            {
                _cartItemRepository.MarkCartItemsAsDeliveredByCartID(cartID);
                return new ServiceResult<bool> { IsSuccees = true, Result = true };

            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>() { IsSuccees = false, Message = "Bad request", Result = false };
            }
        }
        //this method is not optimized and should be done in DB
        public ServiceResult<IEnumerable<ResturantOrderModel>> GetResturantOrdersByRestaurantID(string restaurantID)
        {
            List<CartItem> cartItems = _cartItemRepository.GetUndeliveredCartItemsByRestaurantID(restaurantID);

            var groupByCartIDQuery =
                from cartItem in cartItems
                group cartItem by cartItem.CartID into newCartGroup
                select newCartGroup;
            List<ResturantOrderModel> restauranOrders = new();
            try
            {
                foreach (var cartGroup in groupByCartIDQuery)
                {
                    ResturantOrderModel currentOrder = new();
                    Console.WriteLine(_cartRepository.GetCartByCartID(cartGroup.Key).UserID);
                    currentOrder.User = _userRepository.GetUserByUserID((_cartRepository.GetCartByCartID(cartGroup.Key).UserID));
                    currentOrder.cartID = cartGroup.Key;
                    currentOrder.IsDelivered = false;
                    foreach (var cartItem in cartGroup)
                    {
                        currentOrder.OrderList.Add(new OrderedItemModel(_menuItemRepository.GetMenuItemByID(cartItem.MenuItemID), cartItem.Count, cartItem.Price));
                    }
                    restauranOrders.Add(currentOrder);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<IEnumerable<ResturantOrderModel>>("Orders not retreived")
                {
                    IsSuccees = false,
                };
            }
            return new ServiceResult<IEnumerable<ResturantOrderModel>>("Orders retrived")
            {
                IsSuccees = true,
                Result = restauranOrders
            };
        }
    }

}
