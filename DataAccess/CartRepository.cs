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
    public class CartRepository:ICartRepository
    {
        public void AddCart(Cart cart)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Carts VALUES (@CartID,@UserID,@Date);", connection);
                sqlCommand.Parameters.AddRange(new[]
                {

                       new SqlParameter("@CartID", cart.CartID),
                       new SqlParameter("@UserID", cart.UserID),
                       new SqlParameter("@Date", cart.Date)
                });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Cart GetCartByCartID(string cartID)
        {
            Cart? cart = null;

            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Carts where CartID = @CartID", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "CartID",
                    Value = cartID
                };
                sqlCommand.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cart = new(cartID: reader.GetString(0), userID: reader.GetString(1), date: reader.GetDateTime(2));
                    }

                    return cart ?? null;
                }

            }
        }
    }
}
