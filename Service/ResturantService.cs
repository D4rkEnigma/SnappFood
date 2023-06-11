using Domain.Contracts;
using Domain.Entities;
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
        public ResturantService(IRestaurantRepository resturantRepository,IMenuItemRepository menuItemRepository) 
        {
            _resturantRepository = resturantRepository;
            _menuItemRepository = menuItemRepository;
        }
        public ServiceResult<IEnumerable<Restaurant>> GetRestueantList()
        {
            var resturantList = new ServiceResult<IEnumerable<Restaurant>>();
            if (_resturantRepository.GetRestaurantsList() != null)
            {
                resturantList.Result = _resturantRepository.GetRestaurantsList();
                resturantList.IsSuccees= true;
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
                _resturantRepository.AddRestaurant(restaurant);
                result.IsSuccees = true;
                result.Result = restaurant;
                result.Message = "Successfully Register";
            }
            return result;
        }

        public ServiceResult<IEnumerable<MenuItem>> GetResturantMenu(string resturantId)
        {
            if(_resturantRepository.GetRestaurantById(resturantId) != null)
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
    }
    
}
