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
        public void EditRestaurantByName(string restaurantName, Restaurant editedRestaurant)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("UPDATE Restaurants SET RestaurantID = @RestaurantID, Name = @Name, Password = @Password," +
                    " Manager = @Manager, OpenTime = @OpenTime, CloseTime = @CloseTime, Address= @Address," +
                    " Balance = @Balance WHERE Name = @BaseRestaurantName", connection);
                sqlCommand.Parameters.AddRange(new[]
                {
                       new SqlParameter("@BaseRestaurantName", restaurantName),

                       new SqlParameter("@RestaurantID", editedRestaurant.RestaurantID),
                       new SqlParameter("@Name", editedRestaurant.Name),
                       new SqlParameter("@Password", editedRestaurant.Password),
                       new SqlParameter("@Manager", editedRestaurant.Manager),
                       new SqlParameter("@OpenTime", editedRestaurant.OpenTime),
                       new SqlParameter("@CloseTime", editedRestaurant.CloseTime),
                       new SqlParameter("@Address", editedRestaurant.Address),
                       new SqlParameter("@Balance", editedRestaurant.Balance),
                     });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Restaurant GetRestaurantById(string id)
        {
            Restaurant? restaurant = null;

            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Restaurants where Name = @RestaurantID", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "RestaurantID",
                    Value = id
                };
                sqlCommand.Parameters.Add(sqlParameter);
                
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    
                    if (reader.Read())
                    {
                              restaurant = new Restaurant (restaurantID: reader.GetString(0), name: reader.GetString(1).Trim(),
                                                          password: reader.GetString(2).Trim(), manager: reader.GetString(3).Trim(),
                                                          openTime: reader.GetDateTime(4), closeTime: reader.GetDateTime(5),
                                                           address: reader.GetString(6), balance: reader.GetDecimal(7));
                        
                    }

                    return restaurant ?? null;
                }

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
                                                    openTime: reader.GetDateTime(4), closeTime: reader.GetDateTime(5),
                                                    address: reader.GetString(6), balance: reader.GetDecimal(7));
                                                    restaurants.Add(restaurant);
                    }

                }
                return restaurants;
            }
        }

        

    }
}
