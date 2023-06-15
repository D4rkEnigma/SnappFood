using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiDtos
{
    public class OrderedItemModel
    {
        public MenuItem MenuItem { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public OrderedItemModel(MenuItem menuItem, int count, decimal price )
        {
            MenuItem = menuItem;
            Count = count;
            Price = price;
        }
    }
}
