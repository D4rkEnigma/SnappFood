using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Restaurant
    {
        public string RestaurantID { get; set;   }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Manager { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }

        public Restaurant(string restaurantID, string name, string password, string manager,
            DateTime openTime, DateTime closeTime, string address, decimal balance) 
        {
            RestaurantID = restaurantID;
            Name = name;
            Password = password;
            Manager = manager;
            OpenTime = openTime;
            CloseTime = closeTime;
            Address = address;
            Balance = balance;
        }
    }
}
