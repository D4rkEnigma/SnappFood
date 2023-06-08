using Domain.Entities;
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
    }
}
