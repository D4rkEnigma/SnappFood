using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IPaymentService
    {
        public ServiceResult<bool> Pay(string userNationalCode,Cart order);
    }
}
