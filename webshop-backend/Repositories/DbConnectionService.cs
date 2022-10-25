using MySql.Data.MySqlClient;
using System.Data;

namespace webshop_backend.Repositories
{
    public class DbConnectionService :IDbConnectionService

    {
        //TODO this should not be in code but in appsettings.json
        private static string connectionString = "server=127.0.0.1;port=3306;database=web;user=root;";

        public IDbConnection Create()
        {
            return new MySqlConnection(connectionString);

        }
    }

}

   

