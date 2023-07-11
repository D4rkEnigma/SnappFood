using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public string CartID { get; set; }
        public string MenuItemID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public bool IsDelivered { get; set; }

        public CartItem(string cartID, string menuItemID, decimal price, int count, bool isDelivered)
        {
            CartID = cartID;
            MenuItemID = menuItemID;
            Price = price;
            Count = count;
            IsDelivered = isDelivered;
        }

    }
}
