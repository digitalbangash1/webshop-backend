using webshop_backend.Model;

namespace webshop_backend.Repositories
{
    public interface IShoppingcartRespository
    {
      void creatCart(int id , int product_id, int user_id);
      void updateCart(int id, int product_id, int user_id);
      void deleteCart(int id);
      IList<ShoppingCart> GetCart();
    }
}



