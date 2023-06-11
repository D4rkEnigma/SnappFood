using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICartService
    {

        public void AddMenuItemToUserCart(string userNationalCode,string menuItemId, int count);
        public void CreateCartForUser(User user);

    }
}
