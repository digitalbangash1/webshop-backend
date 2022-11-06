
using MySql.Data.MySqlClient;
using System.Data.Common;
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

        public async Task<LoginResponse> Login(LoginRequest request)
        {

            LoginResponse response = new LoginResponse();
            response.IsSuccess = true;
            response.Message = "Successful";


            try
            {
                
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await sqlConnection.OpenAsync();
                }

                string Sql = @"select * from UserRe where Email=@Email and PassWord=@PassWord and Role=@Role";

                using (MySqlCommand sqlCommand = new MySqlCommand(Sql, sqlConnection))
                {
                    sqlCommand.CommandText = Sql;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Email", request.Email);
                    sqlCommand.Parameters.AddWithValue("@PassWord", request.PassWord);
                    sqlCommand.Parameters.AddWithValue("@Role", request.Role);
                   using(DbDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            response.Message = "Login Successfully";
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "Login Unsuccessfully";
                            return response;
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();
            }
            return response;











        }

        public async Task<SignUpResponse> User(RegisterRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            response.IsSuccess = true;
            response.Message = "Successful";


            try {
                if (!request.PassWord.Equals(request.ConfirmPassWord))
                {
                    response.IsSuccess = false;
                    response.Message = "Confirm Password again please!";
                    return response;
                }
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await sqlConnection.OpenAsync();
                }

                string Sql = @"insert into UserRe (Email,PassWord,Role) values (@Email,@PassWord,@Role)";

                using (MySqlCommand sqlCommand = new MySqlCommand(Sql, sqlConnection)) { 
                    sqlCommand.CommandText = Sql;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Email", request.Email);
                    sqlCommand.Parameters.AddWithValue("@PassWord", request.PassWord);
                    sqlCommand.Parameters.AddWithValue("@Role", request.Role);
                    //sqlCommand.Parameters.AddWithValue("@Name", request.Name);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                        return response;
                    }
                }

            }

            catch(Exception ex) {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();
            }
            return response;
        }
    }
}

