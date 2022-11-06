/*using webshop_backend.Model;
using System.Data;

namespace webshop_backend.Repositories
{
    public class UserRepository : IUserRespository
    {

        private readonly IDbConnectionService dbConnectionService;

        public UserRepository (IDbConnectionService dbConnectionService)
        {
            this.dbConnectionService = dbConnectionService;
        }

        public IList<User> GetUsers()
        {
            var users = new List<User>();
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from User";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(GetUsers(reader));
                    }
                }



            }
            return users;

        }
        private User GetUsers(IDataReader reader)
        {
            return new User()
            {
                ID = Convert.ToInt32(reader["id"]),
                PassWord   = reader["password"].ToString(),
                FirstName  = reader["firstname"].ToString(),
                LastName   = reader["lastname"].ToString(),
                Telephone  = reader["telephone"].ToString(),
                Email      = reader["email"].ToString(),
                AdminID    = reader["adminid"].ToString(),


            };
        }
    }
}*/
