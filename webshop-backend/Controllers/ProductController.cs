using Microsoft.AspNetCore.Mvc;
using webshop_backend.Model.Products;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IProductsRespository productsRespository;

        public ProductsController(IProductsRespository productsRespository)
        {
            this.productsRespository = productsRespository;

        }

        [HttpGet]
        public Action GetProducts()
        {
            return Ok(ProductsRespository.GetProducts());
        }


        [HttpPost]
        public Action CreateProduct(CreateProductModel model)
        {
            ProductsRespository.CreateProduct(model.name, model.description, model.price, model.quantity);
            return Ok();
        } 



        [HttpDelete("{id}")]
        public Action DeleteProduct(int id)
        {
            ProductsRespository.DeleteProduct(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public Action UpdateProduct(int id,UpdateProductModel model)
        {
            ProductsRespository.UpdateProduct(model.name, model.description, model.price, model.quantity);
            return Ok();
        }
    }
}
