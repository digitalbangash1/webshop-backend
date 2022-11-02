using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using webshop_backend.Auth;
using webshop_backend.Model;

namespace webshop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

         public readonly AuthI auth;
        public AuthController(AuthI author)
        {
            auth = author;
        }

        [HttpPost]
        public async Task<ActionResult> User(UserRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            try
            {
                //response = await auth.User(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        /*[HttpPost]
        public async Task<ActionResult> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            try
            {
                response = await auth.SignIn(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }*/





    }
}
