using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiDtos
{
    public class ResturantOrderModel
    {
        public List<OrderedItemModel> OrderList { get; set; }
        public User User { get; set; }
        public bool IsDelivered { get; set; }
        public ResturantOrderModel()
        {
            OrderList = new();
        }
    }
}
