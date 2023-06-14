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
        public ServiceResult<IEnumerable<Restaurant>> GetRestueantList();
        public ServiceResult<Restaurant> GetRestueantById(string id);
        public ServiceResult<Restaurant> RegisterResturant(Restaurant restaurant);
        public ServiceResult<IEnumerable<MenuItem>> GetResturantMenu(string resturantId);
        public ServiceResult<Restaurant> LoginResturant(string username, string password);
        public ServiceResult<bool> AddMenuItem(AddMenuItemModel menuItemModel);
    }
}
