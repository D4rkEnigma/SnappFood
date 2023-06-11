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
    public class CartRepository:ICartItemRepository
    {
        public void AddCart(Cart cart)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Users VALUES (@CartID,@UserID,@Date);", connection);
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

        public Cart GetUserCart(string nationalCode)
        {
            throw new NotImplementedException();
        }
    }
}
