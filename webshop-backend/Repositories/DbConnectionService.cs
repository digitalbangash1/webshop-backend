using MySql.Data.MySqlClient;
using System.Data;

namespace webshop_backend.Repositories
{
    public class DbConnectionService :IDbConnectionService

    {
        //TODO this should not be in code but in appsettings.json
       // private static string connectionString = "server=localhost;port=3306;database=webshop;user=root;password=salim123";
        private static string connectionString = "server=mysql-database-db.admin.samat.diplomportal.dk;port=3306;database=webshop;user=root;password=salim123";



        //"server=mysql-database-db.admin.samat.diplomportal.dk;port=3306;database=webshop;user=root;password=salim123";
        //"server=localhost;port=3306;database=webshop;user=root;password=Wajiha3330";
        //
        //server=localhost;port=3306;database=webshop;user=root;password=123456
        public IDbConnection Create()
        {
            return new MySqlConnection(connectionString);

        }

        public IDbConnection Delete()
        {
            return new MySqlConnection(connectionString);

        }
    }

}

   

