using webshop_backend.Model.Products;

namespace webshop_backend.Repositories
{
    public interface IProductsRespository
    {
        void CreateProduct(string name, string description, int price, int quantity);
        void UpdateProduct(int id, string name, string description, int price, int quantity);
        IList<ProductsModel> GetProducts();
        void DeleteProduct(int id);
    }
}



