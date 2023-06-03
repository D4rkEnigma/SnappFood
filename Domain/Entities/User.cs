using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public string UserID { get; set; }
        public int NationalCode { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public User(string userID, int nationalCode, string password, string name,string address, decimal balance)
        {
            UserID = userID;
            NationalCode = nationalCode;
            Name = name;
            Password = password;
            Address = address;
            Balance = balance;
        }
    }
}
