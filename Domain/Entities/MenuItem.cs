using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MenuItem
    {
        public string MenuItemID { get; set; }
        public string RestaurantID { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public TimeOnly CookingTime { get; set; }
        public MenuItem(string menuItemID,string restaurantID, string foodName, decimal price,TimeOnly cookingTime )
        {
            MenuItemID = menuItemID;
            RestaurantID = restaurantID;
            FoodName = foodName;
            Price = price;
            CookingTime = cookingTime;
        }

    }
}
