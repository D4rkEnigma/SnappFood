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
        private readonly IPaymentService paymentService;

        public CartService(ICartItemRepository _cartItemRepository,IUserRepository _userRepository,ICartRepository _cartRepository,IMenuItemService menuItemService,IPaymentService paymentService) 
        { 
            cartItemRepository= _cartItemRepository;
            userRepository= _userRepository;
            cartRepository = _cartRepository;
            this.menuItemService = menuItemService;
            this.paymentService = paymentService;
        }

        public ServiceResult<bool> CreateOrder(List<CartItem> orderList,string userNationalCode)
        {
            var OrderCart = new Cart(Guid.NewGuid().ToString(), userNationalCode, DateTime.Now);
            foreach (var item in orderList)
            {
                OrderCart.Items.Add(item);
            }
            var payResult = paymentService.Pay(userNationalCode, OrderCart);
            if (payResult.Result) 
            {
                cartRepository.AddCart(OrderCart);
                foreach (var item in orderList)
                {

                    item.CartID = OrderCart.CartID;
                    cartItemRepository.AddCartItem(item);
                }
                return new ServiceResult<bool> { Result = true };
            }
            else
            {
                return new ServiceResult<bool> { Result = false };
            }

            
        }

        //public void CreateCartForUser(User user)
        //{                        
        //    var userCart = new Cart(Guid.NewGuid().ToString(), user.NationalCode, DateTime.Now);
        //    cartRepository.AddCart(userCart);           
        //}

    }
}
