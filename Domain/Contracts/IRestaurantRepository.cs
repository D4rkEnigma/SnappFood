﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRestaurantRepository
    {
        void AddRestaurant(Restaurant restaurant);
        List<Restaurant> GetRestaurantsList();
        Restaurant GetRestaurantById(string id);
        void EditRestaurantByName(string restaurantName, Restaurant editedRestaurant);


    }
}
