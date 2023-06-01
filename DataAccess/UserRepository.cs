using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class UserRepository
    {
        public User TryGetUserByUsername(string Username)
        {
            User user;

            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Users where Username = @Username", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "Username",
                    Value = Username
                };
                sqlCommand.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new(userID: reader.GetString(0), username: reader.GetString(1).Trim(), password: reader.GetString(2).Trim(),
                    name: reader.GetString(3).Trim(), balance: reader.GetDecimal(4));
                    }
                    else
                    {
                        return new ServiceResultError<User>("Error");
                    }

                }
                return new SuccessfulServiceResult<User>(user);
            }
        }
    }
}
