
using Microsoft.AspNetCore.Mvc;
using webshop_backend.Model;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRespository userRespository;
        public UserController(IUserRespository userRespository)
        {
            this.userRespository = userRespository;

        }
        [HttpGet]
        public IList<User> GetUsers()
        {
            return userRespository.GetUsers();
        }





    }
}
