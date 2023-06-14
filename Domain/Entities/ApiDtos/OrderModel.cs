using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiDtos
{
    public class OrderModel
    {
        public MenuItem MenuItem { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
