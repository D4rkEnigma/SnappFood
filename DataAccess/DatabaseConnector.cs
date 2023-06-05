
using System.Data.SqlClient;

namespace BookStore.Domain.Entities
{
    public static class DatabaseConnector
    {


        //static readonly string _dataSource = @"DESKTOP-56TR48K\SQLEXPRESS";//your server
        //static readonly string _database = "SnappFood"; //your database name
        //static readonly string _username = "sa"; //username of server to connect
       // static readonly string _password = "123"; //password
                                                  //your connection string 
        static readonly string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SnappFood;Data Source=DESKTOP-56TR48K\SQLEXPRESS";

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }

    }
}
