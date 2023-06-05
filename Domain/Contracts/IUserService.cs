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
        public ServiceResult<User> GetUser(int nationalCode);
        public ServiceResult<IEnumerable<User>> GetAllUser();
        public ServiceResult<User> RegisterUser(User user);
    }
}
