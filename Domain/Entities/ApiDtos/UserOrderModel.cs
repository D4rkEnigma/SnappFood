using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.WebRequestModels
{
    public class UserOrderModel
    {
        public List<CartItem> OrderItem { get; set; }
        public string userNationalCode { get; set; }
    }
}
