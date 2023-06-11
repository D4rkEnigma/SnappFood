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
    public class CartItemRepository: ICartItemRepository
    {
        public void AddCartItem(CartItem cartItem)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Users VALUES (@CartID,@MenuItemID,@Price,@Count,@IsDelivered);", connection);
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
    }
}
