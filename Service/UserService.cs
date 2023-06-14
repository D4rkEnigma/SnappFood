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
    public class UserService : IUserService
    {
        public IUserRepository userRrepoisitory;
        public ICartService cartService;
        public UserService(IUserRepository userRrepoisitory, ICartService cartService)
        {
            this.userRrepoisitory = userRrepoisitory;
            this.cartService = cartService;
        }
        public ServiceResult<User> RegisterUser(User user)
        {
            if (user == null) 
            {
                return new ServiceResult<User>("Null Request")
                {
                    IsSuccees = false,
                };
            }
            else if(userRrepoisitory.GetUserByNationalCode(user.NationalCode) != null) 
            {
                return new ServiceResult<User>("This User Already Exist")
                {
                    IsSuccees = false,
                };
            }
            else
            {
                user.UserID = Guid.NewGuid().ToString();    
                userRrepoisitory.AddUser(user);                 
                return new ServiceResult<User>("SuccessFully Login")
                {
                    Result = user,
                    IsSuccees = true,
                };
            }
            
        }

        public ServiceResult<User> LoginUser(string natinalCode,string password) 
        {
            User _user = userRrepoisitory.GetUserByNationalCode(natinalCode);
            if (_user == null)
            {
                return new ServiceResult<User>("User Not Exist")
                {
                    IsSuccees = false,

                };
            }
            else if(password != _user.Password) 
            {
                return new ServiceResult<User>("Password Is Incorrect")
                {
                    IsSuccees = false,
                };
            }
            else
            {
                return new ServiceResult<User>("Successfully login")
                {
                    IsSuccees = true,
                    Result = _user,
                };
            }    
        }

        public ServiceResult<User> GetUser(string nationalCode)
        {
            User user = userRrepoisitory.GetUserByNationalCode(nationalCode);
            if (user == null)
            {
                return new ServiceResult<User>("User Not Found")
                {

                    IsSuccees = false,
                };
            }
            else
            {
                return new ServiceResult<User>("Successfull")
                {
                    Result= user,
                    IsSuccees = true,
                };
            }

        }


    }
}
