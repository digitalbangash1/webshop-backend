using Microsoft.AspNetCore.Mvc;

namespace webshop_backend.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
