﻿using BookStore.Domain.Entities;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("INSERT INTO Users VALUES (@UserID,@Name,@Password,@NationalCode,@Address,@Balance);", connection);
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
        public void EditUserByNationalCode(string nationalCode, User updatedUser)
        {
            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                SqlCommand sqlCommand = new("UPDATE Users SET UserID = @UserID, Name = @Name, Password = @Password, NationalCode = @NationalCode, Address = @Address, Balance = @Balance WHERE NationalCode = @BaseNationalCode", connection);
                sqlCommand.Parameters.AddRange(new[]
                {
                       new SqlParameter("@BaseNationalCode", nationalCode),

                       new SqlParameter("@UserID", updatedUser.UserID),
                       new SqlParameter("@Name", updatedUser.Name),
                       new SqlParameter("@Password", updatedUser.Password),
                       new SqlParameter("@NationalCode", updatedUser.NationalCode),
                       new SqlParameter("@Address", updatedUser.Address),
                       new SqlParameter("@Balance", updatedUser.Balance),
                     });
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public User GetUserByNationalCode(string nationalCode)
        {
            User? user = null;

            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Users where NationalCode = @NationalCode", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "NationalCode",
                    Value = nationalCode
                };
                sqlCommand.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new(userID: reader.GetString(0), name: reader.GetString(1).Trim(), password: reader.GetString(2).Trim(),
                    nationalCode: reader.GetString(3),address: reader.GetString(4).Trim(), balance: reader.GetDecimal(5));
                    }

                    return user ?? null;
                }
                
            }
        }

        public User GetUserByUserID(string userID)
        {
            User? user = null;

            SqlConnection connection = DatabaseConnector.Connect();
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new("select * from Users where UserID = @UserID", connection);
                SqlParameter sqlParameter = new()
                {
                    ParameterName = "UserID",
                    Value = userID
                };
                sqlCommand.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new(userID: reader.GetString(0), name: reader.GetString(1).Trim(), password: reader.GetString(2).Trim(),
                    nationalCode: reader.GetString(3), address: reader.GetString(4).Trim(), balance: reader.GetDecimal(5));
                    }

                    return user ?? null;
                }

            }
        
        }
    }
}
