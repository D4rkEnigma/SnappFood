using BookStore.Domain.Entities;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MenuItemRepository : IMenuItemRepository
    {
        public void AddMenuItem(MenuItem menuItem)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Users VALUES (@MenuItemID,@RestaurantID,@FoodName,@Price,@CookingTime);", connection);
                sqlCommand.Parameters.AddRange(new[]
                {

                       new SqlParameter("@MenuItemID", menuItem.MenuItemID),
                       new SqlParameter("@RestaurantID", menuItem.RestaurantID),
                       new SqlParameter("@FoodName", menuItem.FoodName),
                       new SqlParameter("@Price", menuItem.Price),
                       new SqlParameter("@CookingTime", menuItem.CookingTime)
                });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<MenuItem> GetMenuItemsListByRestaurantID(string id)
        {
            List<MenuItem> menuItems = new();
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                
                SqlCommand sqlCommand = new("SELECT * FROM Restaurants WHERE RestaurantID = @RestaurantID", connection);
                sqlCommand.Parameters.AddRange(new[]
{

                       new SqlParameter("@RestaurantID", id)
                });

                connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    do
                    {
                        MenuItem menuItem = new(menuItemID: reader.GetString(0), restaurantID: reader.GetString(1),
                            foodName: reader.GetString(2).Trim(), price: reader.GetDecimal(3),
                            cookingTime: TimeOnly.FromDateTime(reader.GetDateTime(4)));
                        menuItems.Add(menuItem);
                    } while (reader.Read());
                }
                return menuItems;
            }
        }
    }
}
