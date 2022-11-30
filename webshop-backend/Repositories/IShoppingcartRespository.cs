using webshop_backend.Model;

namespace webshop_backend.Repositories
{
    public interface IShoppingcartRespository
    {
      void creatCart(int id , int product_id, string user_email);
      void updateCart(int id, int product_id, string user_email);
      void deleteCart(int id);
      IList<ShoppingCart> GetCart();
    }
}



