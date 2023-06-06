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
        void EditUserByNationalCode(string nationalCode, User updatedUser);
        User GetUserByNationalCode(string NationalCode);

    }
}
