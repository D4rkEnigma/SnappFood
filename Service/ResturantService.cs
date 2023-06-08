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
    public class ResturantService : IResturantService
    {
        private readonly IRestaurantRepository _resturantRepository;
        public ResturantService(IRestaurantRepository resturantRepository) 
        {
            _resturantRepository = resturantRepository;
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

            _resturantRepository.AddRestaurant(restaurant);
        }
    }
    }
}
