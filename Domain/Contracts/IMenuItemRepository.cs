using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IMenuItemRepository
    {
        public void AddMenuItem(MenuItem menuItem);
        public List<MenuItem> GetMenuItemsListByRestaurantID(string id);
        public MenuItem GetMenuItemByID(string menuItemId);
    }
}
