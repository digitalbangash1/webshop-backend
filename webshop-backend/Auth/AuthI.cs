using Microsoft.Graph;
using webshop_backend.Model;

namespace webshop_backend.Auth
{
    public interface AuthI
    {
        Task<SignUpResponse> User(UserRequest request);
    }
}
