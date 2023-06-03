using BookStore.Domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class RestaurantRepository
    {
        public static void AddUser(User user)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Restaurants VALUES (@RestaurantID,@Name,@Password,@Manager,@OpenTime,@CloseTime,@Address,@);", connection);
                sqlCommand.Parameters.AddRange(new[]
                {

                       new SqlParameter("@UserID", user.UserID),
                       new SqlParameter("@Name", user.Name),
                       new SqlParameter("@Password", user.Password),
                       new SqlParameter("@NationalCode", user.NationalCode),
                       new SqlParameter("@Address", user.Address),
                       new SqlParameter("@Balance", user.Balance),
                     });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static List<Restaurant> GetRestaurantsList()
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
