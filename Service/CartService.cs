using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Events;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartItemRepository
    {
        private readonly ICartItemRepository cartItemRepository;
        private readonly IUserRepository userRepository;
        private readonly ICartItemRepository cartRepository;

        public CartService(ICartItemRepository _cartItemRepository,IUserRepository _userRepository,ICartItemRepository _cartRepository) 
        { 
            cartItemRepository= _cartItemRepository;
            userRepository= _userRepository;
            cartRepository = _cartRepository;
        }

        public void AddCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<Cart> AddMenuItemToUserCart(string userNationalCode, string menuItemId)
        {
            var user = userRepository.GetUserByNationalCode(userNationalCode);

        }

        public void CreateCartForUser(User user)
        {                        
            var userCart = new Cart(Guid.NewGuid().ToString(), user.NationalCode, DateTime.Now);
            cartRepository.AddCart(userCart);           
        }

        public Cart GetUserCart(string nationalCode)
        {
            throw new NotImplementedException();
        }
    }
}
