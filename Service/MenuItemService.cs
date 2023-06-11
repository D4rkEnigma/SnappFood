using Domain.Contracts;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MenuItemService : IMenuItemService 
    {
        private readonly IMenuItemRepository menuItemRepository;
        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }
        public ServiceResult<decimal> CalculateMenuItemPrice(string menuitemID)
        {
            var menuItem = menuItemRepository.GetMenuItemByID(menuitemID);
            return new ServiceResult<decimal>()
            {
                Result = 1 * menuItem.Price,
                IsSuccees = true,
            };
        }
    }
}
