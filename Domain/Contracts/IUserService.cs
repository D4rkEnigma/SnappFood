using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserService
    {
        public ServiceResult<User> GetUser(string nationalCode);
        public ServiceResult<User> RegisterUser(User user);
        public ServiceResult<User> LoginUser(string natinalCode, string password);
    }
}
