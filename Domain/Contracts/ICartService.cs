using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICartItemRepository
    {

        public ServiceResult<Cart> AddMenuItemToUserCart(string userNationalCode,string menuItemId);

    }
}
