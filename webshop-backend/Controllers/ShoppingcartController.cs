using Microsoft.AspNetCore.Mvc;
using webshop_backend.Model;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    [ApiController]
    [Route("Cart")]
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingcartRespository ShoppingcartRespository;

        public ShoppingCartController(IShoppingcartRespository ShoppingcartRespository)
        {
            this.ShoppingcartRespository = ShoppingcartRespository;

        }

        [HttpGet]
        public IActionResult GetCart()
        {
            return Ok(ShoppingcartRespository.GetCart());
        }


        [HttpPost]
        public IActionResult creatCart(ShoppingCart model)
        {
            ShoppingcartRespository.creatCart(model.id, model.product_id, model.user_id);
            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            ShoppingcartRespository.deleteCart(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult updateCart(int id, ShoppingCart model)
        {
            ShoppingcartRespository.updateCart(id, model.product_id, model.user_id);
            return Ok();
        }
    }
}

