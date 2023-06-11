using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IMenuItemService
    {
        public ServiceResult<decimal> CalculateMenuItemPrice(string menuitemID);
    }
}
