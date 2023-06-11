using Domain.Contracts;
using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartService
    {
        private readonly ICartItemRepository cartItemRepository;
        private readonly IUserRepository userRepository;
        private readonly ICartRepository cartRepository;
        private readonly IMenuItemService menuItemService;

        public CartService(ICartItemRepository _cartItemRepository,IUserRepository _userRepository,ICartRepository _cartRepository,IMenuItemService menuItemService) 
        { 
            cartItemRepository= _cartItemRepository;
            userRepository= _userRepository;
            cartRepository = _cartRepository;
            this.menuItemService = menuItemService;
        }

        public void AddMenuItemToUserCart(string userNationalCode, string menuItemId,int count)
        {
            var user = userRepository.GetUserByNationalCode(userNationalCode);
            var userCart = cartRepository.GetUserCart(user.NationalCode);
            var menuItemPrice = menuItemService.CalculateMenuItemPrice(menuItemId).Result;
            var cartItem = new CartItem(userCart.CartID,menuItemId,menuItemPrice,count,false);
            cartItemRepository.AddCartItem(cartItem);
        }

        public void CreateCartForUser(User user)
        {                        
            var userCart = new Cart(Guid.NewGuid().ToString(), user.NationalCode, DateTime.Now);
            cartRepository.AddCart(userCart);           
        }

    }
}
