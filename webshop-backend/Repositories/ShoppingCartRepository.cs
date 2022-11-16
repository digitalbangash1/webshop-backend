using webshop_backend.Model;
using System.Data;

namespace webshop_backend.Repositories
{
    public class ShoppingCartRespository :IShoppingcartRespository
    {
       

        private readonly IDbConnectionService dbConnectionService;

        public ShoppingCartRespository(IDbConnectionService dbConnectionService)
        {
            this.dbConnectionService = dbConnectionService;
        }






        public void creatCart(int id, int product_id, int user_id)
        {
            using (var conaction = dbConnectionService.Create())
            {
                conaction.Open();
                var db = conaction.CreateCommand();
                db.CommandType = CommandType.Text;

                db.CommandText = "INSERT INTO shoppingCart (id , product_id, user_id) VALUES (@id, @product_id, @user_id)";


                var idParam = db.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                db.Parameters.Add(idParam);

                var pIdParam = db.CreateParameter();
                pIdParam.ParameterName = "@product_id";
                pIdParam.Value = product_id;
                db.Parameters.Add(pIdParam);

                var uIdParam = db.CreateParameter();
                uIdParam.ParameterName = "@user_id";
                uIdParam.Value = user_id;
                db.Parameters.Add(uIdParam);

                db.ExecuteNonQuery();
            }
        }



        public void updateCart(int id, int product_id, int user_id)
        {
            using (var conaction = dbConnectionService.Create())
            {
                conaction.Open();
                var db = conaction.CreateCommand();

                db.CommandType = CommandType.Text;
                db.CommandText = "UPDATE shoppingCart SET id=@id, product_id=@product_id, user_id=@user_id  WHERE id=@id";


                var idParam = db.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                db.Parameters.Add(idParam);

                var pIdParam = db.CreateParameter();
                pIdParam.ParameterName = "@product_id";
                pIdParam.Value = product_id;
                db.Parameters.Add(pIdParam);

                var uIdParam = db.CreateParameter();
                uIdParam.ParameterName = "@user_id";
                uIdParam.Value = user_id;
                db.Parameters.Add(uIdParam);

                db.ExecuteNonQuery();
            }

        }

        public IList<ShoppingCart> GetCart()
        {
            var ShoppingCart = new List<ShoppingCart>();
            using (var conaction = dbConnectionService.Create())
            {
                conaction.Open();
                var db = conaction.CreateCommand();
                db.CommandType = CommandType.Text;
                db.CommandText = "select * from shoppingCart";

                using (var reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ShoppingCart.Add(GetCart(reader));
                    }
                }

            }
            return ShoppingCart;

        }


        private ShoppingCart GetCart(IDataReader reader)
        {
            return new ShoppingCart
            {
                id = Convert.ToInt32(reader["id"]),
                product_id = Convert.ToInt32(reader["product_id"]),
                user_id = Convert.ToInt32(reader["user_id"])


            };
        }


        public void deleteCart(int id)
        {
            using (var conaction = dbConnectionService.Create())
            {
                conaction.Open();
                var db = conaction.CreateCommand();
                db.CommandType = CommandType.Text;
                db.CommandText = "DELETE FROM shoppingCart WHERE id=@id";

                var idParam = db.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                db.Parameters.Add(idParam);
                db.ExecuteNonQuery();
            };
        }
    }
    }
