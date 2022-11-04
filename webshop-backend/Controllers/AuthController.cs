
using Microsoft.AspNetCore.Mvc;
using webshop_backend.Auth;
using webshop_backend.Model;


namespace webshop_backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

         public readonly AuthI auth;
        public AuthController(AuthI author)
        {
            auth = author;
        }

        [HttpPost]
        public async Task<ActionResult> User(RegisterRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            try
            {
                response = await auth.User(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                response = await auth.Login(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }





    }
}
