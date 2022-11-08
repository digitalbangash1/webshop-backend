using webshop_backend.Model.Products;

namespace webshop_backend.Repositories
{
    public interface IProductsRespository
    {
        void CreateProduct(string name, string description, decimal price, int quantity, string imageLink);
        void UpdateProduct(int id, string name, string description, decimal price, int quantity, string imageLink);
        IList<ProductsModel> GetProducts();
        void DeleteProduct(int id);
       
    }
}



