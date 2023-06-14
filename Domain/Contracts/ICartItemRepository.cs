using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICartItemRepository
    {
        public void AddCartItem(CartItem cartItem);
        void EditCartItemByCartIdAndMenuItemID(string baseCartID, string baseMenuItemID, CartItem editedCartItem);
        List<CartItem> GetUndeliveredCartItemsByRestaurantID(string restaurantID);
    }
}
