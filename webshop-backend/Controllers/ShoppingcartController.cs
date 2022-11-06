using Microsoft.AspNetCore.Mvc;
using webshop_backend.Model.Products;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    public class ShoppingcartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

