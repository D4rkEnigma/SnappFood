using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Cart
    {
        public string CartID { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public List<CartItem> Items { get; set; }
        public Cart(string cartID, string userID, DateTime date)
        {
            CartID = cartID;
            UserID = userID;
            Date = date;
            Items = new();
        }
    }
}
