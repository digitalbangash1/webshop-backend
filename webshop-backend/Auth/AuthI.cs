using Microsoft.Graph;
using webshop_backend.Model;

namespace webshop_backend.Auth
{
    public interface AuthI
    {
      public  Task<SignUpResponse> User(RegisterRequest request);
      public  Task<LoginResponse> Login(LoginRequest request);
    }  
}
