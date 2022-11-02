using Microsoft.Graph;
using webshop_backend.Model;

namespace webshop_backend.Auth
{
    public class Author : AuthI
    {
        public readonly IConfiguration conf;
        public Author(IConfiguration conf)
        {
            this.conf = conf;
        }


        public Task<SignUpResponse> User(UserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

