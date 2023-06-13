﻿using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICartService
    {

        public ServiceResult<bool> CreateOrder(List<CartItem> orderList, string userNationalCode);
        //public void CreateCartForUser(User user);

    }
}
