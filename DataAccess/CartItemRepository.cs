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
    public class CartItemRepository : ICartItemRepository
    {
        public void AddCartItem(CartItem cartItem)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO CartItems VALUES (@CartID,@MenuItemID,@Price,@Count,@IsDelivered);", connection);
                sqlCommand.Parameters.AddRange(new[]
                {

                       new SqlParameter("@CartID", cartItem.CartID),
                       new SqlParameter("@MenuItemID", cartItem.MenuItemID),
                       new SqlParameter("@Price", cartItem.Price),
                       new SqlParameter("@Count", cartItem.Count),
                       new SqlParameter("@IsDelivered", cartItem.IsDelivered)
                });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<CartItem> GetUndeliveredCartItemsByRestaurantID(string restaurantID)
        {
            List<CartItem> cartItems = new();
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {

                connection.Open();
                SqlCommand sqlCommand = new("SELECT CartItems.CartID, CartItems.MenuItemID, CartItems.Price, CartItems.Count, CartItems.IsDelivered " +
                    "FROM Carts JOIN CartItems ON Carts.CartID = CartItems.CartID JOIN MenuItems ON CartItems.MenuItemID = MenuItems.MenuItemID WHERE RestaurantID = @RestaurantID", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "RestaurantID",
                    Value = restaurantID
                };
                sqlCommand.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cartItems.Add(new(cartID: reader.GetString(0), menuItemID: reader.GetString(1), price: reader.GetDecimal(2),
                           count: reader.GetInt32(3), isDelivered: reader.GetBoolean(4)));
                    }
                }
                return cartItems;
            }
        }
        public void EditCartItemByCartIdAndMenuItemID(string baseCartID, string baseMenuItemID, CartItem editedCartItem)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("UPDATE CartItems SET CartItems.CartID = @CartID , CartItems.MenuItemID = @MenuItemID, CartItems.Price = @Price," +
                    "CartItems.Count = @Count, CartItems.IsDelivered = @IsDelivered" +
                    "FROM Carts JOIN CartItems ON Carts.CartID = CartItems.CartID JOIN MenuItems ON CartItems.MenuItemID = MenuItems.MenuItemID WHERE Carts.CartID = @BaseCartID AND MenuItems.MenuItemID = @BaseMenuItemID", connection);

                sqlCommand.Parameters.AddRange(new[]
                {
                       new SqlParameter("@BaseCartID", baseCartID),
                       new SqlParameter("@BaseMenuItemID", baseMenuItemID),

                       new SqlParameter("@CartID", editedCartItem.CartID),
                       new SqlParameter("@MenuItemID", editedCartItem.MenuItemID),
                       new SqlParameter("@Price", editedCartItem.Price),
                       new SqlParameter("@Count", editedCartItem.Count),
                       new SqlParameter("@IsDelivered", editedCartItem.IsDelivered)
                     });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
