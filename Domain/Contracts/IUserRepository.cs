using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void EditUserByNationalCode(int nationalCode, User updatedUser);
        User GetUserByNationalCode(int NationalCode);
        IEnumerable<User> GetAllUser();
    }
}
