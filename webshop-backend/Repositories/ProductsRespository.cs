using webshop_backend.Model.Products;
using System.Data;

namespace webshop_backend.Repositories
{
    public class ProductsRespository : IProductsRespository
    {

        private readonly IDbConnectionService dbConnectionService;

        public ProductsRespository(IDbConnectionService dbConnectionService)
        {
            this.dbConnectionService = dbConnectionService;
        }

        public void CreateProduct(string name, string description, int price, int quantity)
        {
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO products (name, description, price, quantity) VALUES (@name, @description, @price, @quantity)";

                var nameParam = cmd.CreateParameter();
                nameParam.ParameterName = "@name";
                nameParam.Value = name;
                cmd.Parameters.Add(nameParam);

                var descriptionParam = cmd.CreateParameter();
                descriptionParam.ParameterName = "@description";
                descriptionParam.Value = description;
                cmd.Parameters.Add(descriptionParam);

                var priceParam = cmd.CreateParameter();
                priceParam.ParameterName = "@price";
                priceParam.Value = price;
                cmd.Parameters.Add(priceParam);

                var quantityParam = cmd.CreateParameter();
                quantityParam.ParameterName = "@quantity";
                quantityParam.Value = description;
                cmd.Parameters.Add(quantityParam);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(string name, string description, int price, int quantity)
        {
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO products (name, description, price, quantity) VALUES (@name, @description, @price, @quantity)";

                var nameParam = cmd.CreateParameter();
                nameParam.ParameterName = "@name";
                nameParam.Value = name;
                cmd.Parameters.Add(nameParam);

                var descriptionParam = cmd.CreateParameter();
                descriptionParam.ParameterName = "@description";
                descriptionParam.Value = description;
                cmd.Parameters.Add(descriptionParam);

                var priceParam = cmd.CreateParameter();
                priceParam.ParameterName = "@price";
                priceParam.Value = price;
                cmd.Parameters.Add(priceParam);

                var quantityParam = cmd.CreateParameter();
                quantityParam.ParameterName = "@quantity";
                quantityParam.Value = description;
                cmd.Parameters.Add(quantityParam);

                cmd.ExecuteNonQuery();
            }

        }

        public IList<ProductsModel> GetProducts()
            {
                var products = new List<ProductsModel>();
                using (var conn = dbConnectionService.Create())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from mytable";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(GetProducts(reader));
                        }
                    }

                }
                return products;

            }

        private ProductsModel GetProducts(IDataReader reader)
        {
            return new ProductsModel()
            {
                id = Convert.ToInt32(reader["id"]),
                name = reader["name"].ToString(),
                description = reader["description"].ToString(),
                price = Convert.ToInt32(reader["price"]),
                quantity = Convert.ToInt32(reader["quantity"]),
                category_id = Convert.ToInt32(reader["category_id"]),

            };
        }


        public void DeleteProduct(int Id)
        {
            using (var conn = dbConnectionService.Delete())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM product WHERE productID=@id";

                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = Id;
                cmd.Parameters.Add(idParam);
                cmd.ExecuteNonQuery();
            };
        }


    }
}