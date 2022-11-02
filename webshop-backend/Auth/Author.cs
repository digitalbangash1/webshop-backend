using Microsoft.Graph;
using MySql.Data.MySqlClient;
using webshop_backend.Model;

namespace webshop_backend.Auth
{
    public class Author : AuthI
    {
        public readonly IConfiguration conf;
        public readonly MySqlConnection sqlConnection;
        public Author(IConfiguration config)
        {
            conf = config;
            sqlConnection = new MySqlConnection(conf["ConnectionStrings:DBConnectionString"]);
        }

        public Task<LoginResponse> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<SignUpResponse> User(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

