using BookStore.Domain.Entities;
using Domain.Contracts;
using Domain.Entities;
using Domain.ServiceResult;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RestaurantRepository:IRestaurantRepository
    {
        public void AddRestaurant(Restaurant restaurant)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Restaurants VALUES (@RestaurantID,@Name,@Password,@Manager,@OpenTime,@CloseTime,@Address,@Balance);", connection);
                sqlCommand.Parameters.AddRange(new[]
                {

                       new SqlParameter("@RestaurantID", restaurant.RestaurantID),
                       new SqlParameter("@Name", restaurant.Name),
                       new SqlParameter("@Password", restaurant.Password),
                       new SqlParameter("@Manager", restaurant.Manager),
                       new SqlParameter("@OpenTime", restaurant.OpenTime),
                       new SqlParameter("@CloseTime", restaurant.CloseTime),
                       new SqlParameter("@Address", restaurant.Address),
                       new SqlParameter("@Balance", restaurant.Balance),
                     });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<Restaurant> GetRestaurantsList()
        {
            List<Restaurant> restaurants = new();
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Restaurants", connection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Restaurant restaurant = new(restaurantID: reader.GetString(0), name: reader.GetString(1).Trim(),
                                                    password: reader.GetString(2).Trim(), manager: reader.GetString(3).Trim(),
                                                    openTime: TimeOnly.FromDateTime(reader.GetDateTime(4)), closeTime: TimeOnly.FromDateTime(reader.GetDateTime(5)),
                                                    address: reader.GetString(6), balance: reader.GetDecimal(7));
                                                    restaurants.Add(restaurant);
                    }

                }
                return restaurants;
            }
        }


    }
}
