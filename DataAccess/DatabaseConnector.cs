
using System.Data.SqlClient;

namespace BookStore.Domain.Entities
{
    public static class DatabaseConnector
    {


        static readonly string _dataSource = @"DESKTOP-VC6KK1O\ENIGMA";//your server
        static readonly string _database = "SnappFood"; //your database name
        static readonly string _username = "sa"; //username of server to connect
        static readonly string _password = "123"; //password
                                                  //your connection string 
        static readonly string connectionString = @"Data Source=" + _dataSource + ";Initial Catalog="
                        + _database + ";Persist Security Info=True;User ID=" + _username + ";Password=" + _password;

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }

    }
}
