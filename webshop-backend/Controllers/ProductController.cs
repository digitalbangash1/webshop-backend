using Microsoft.AspNetCore.Mvc;
using webshop_backend.Model.Products;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IProductsRespository ProductsRespository;

        public ProductsController(IProductsRespository productsRespository)
        {
            this.ProductsRespository = productsRespository;

        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductsRespository.GetProducts());
        }


        [HttpPost]
        public IActionResult CreateProduct(CreateProductModel model)
        {
            ProductsRespository.CreateProduct(model.name, model.description, model.price, model.quantity);
            return Ok();
        } 



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            ProductsRespository.DeleteProduct(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,UpdateProductModel model)
        {
            ProductsRespository.UpdateProduct(id, model.name, model.description, model.price, model.quantity);
            return Ok();
        }
    }
}
