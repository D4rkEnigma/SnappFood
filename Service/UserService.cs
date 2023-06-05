﻿using Domain.Contracts;
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
        public UserService(IUserRepository userRrepoisitory)
        {
            this.userRrepoisitory = userRrepoisitory;   
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
            else
            {
                userRrepoisitory.AddUser(user);
                return new ServiceResult<User>("SuccessFully Login")
                {
                    Result = user,
                    IsSuccees = true,
                };
            }
            
        }

        public ServiceResult<User> LoginUser(User user) 
        {
            User _user = userRrepoisitory.GetUserByNationalCode(user.NationalCode);
            if (_user == null)
            {
                return new ServiceResult<User>("User Not Exist")
                {
                    IsSuccees = false,

                };
            }
            else if(user.Password != _user.Password) 
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

        public ServiceResult<User> GetUser(int nationalCode)
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

        public ServiceResult<IEnumerable<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }
    }
}