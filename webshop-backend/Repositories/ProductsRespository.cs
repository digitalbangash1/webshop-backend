using System.Data;
using webshop_backend.Extensions;
using webshop_backend.Model;
using webshop_backend.Model.Products;

namespace webshop_backend.Repositories
{
    public class ProductsRespository : IProductsRespository
    {

        private readonly IDbConnectionService dbConnectionService;

        public ProductsRespository(IDbConnectionService dbConnectionService)
        {
            this.dbConnectionService = dbConnectionService;
        }

        public void CreateProduct(string name, string description, decimal price, int quantity, string imagelink)
        {
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO product (name, description, price, quantity, imagelink) VALUES (@name, @description, @price, @quantity, @imagelink)";


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
                quantityParam.Value = quantity;
                cmd.Parameters.Add(quantityParam);

                var imagelinkParam = cmd.CreateParameter();
                imagelinkParam.ParameterName = "@imagelink";
                imagelinkParam.Value = imagelink;
                cmd.Parameters.Add(imagelinkParam);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(int id, string name, string description, decimal price, int quantity, string imagelink)
        {
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE product SET name=@name, description=@description, price=@price, quantity=@quantity, imagelink=@imagelink WHERE id=@id";

                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                cmd.Parameters.Add(idParam);

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
                quantityParam.Value = quantity;
                cmd.Parameters.Add(quantityParam);

                var imagelinkParam = cmd.CreateParameter();
                imagelinkParam.ParameterName = "@imagelink";
                imagelinkParam.Value = imagelink;
                cmd.Parameters.Add(imagelinkParam);

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
                cmd.CommandText = "select * from product";

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
                price = Convert.ToDecimal(reader["price"]),
                quantity = Convert.ToInt32(reader["quantity"]),
                type = reader["type"].ToString(),
                imagelink = reader["imagelink"].ToString(),


            };
        }


        public void DeleteProduct(int id)
        {
            using (var conn = dbConnectionService.Delete())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM product WHERE id=@id";

                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                cmd.Parameters.Add(idParam);
                cmd.ExecuteNonQuery();
            };


        }

        public ProductsDetailModel GetProductsDetail(int id)
        {
            ProductsDetailModel? model = null;
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                     select a.*, 
b.product_id, b.rating,b.review from product a 
left outer join Feedback b
on a.id = b.product_id
where a.id = @id
                ";

                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                cmd.Parameters.Add(idParam);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (model == null)
                        {
                            model = new ProductsDetailModel
                            {
                                id = Convert.ToInt32(reader["id"]),
                                name = reader["name"].ToString(),
                                description = reader["description"].ToString(),
                                imagelink = reader["imagelink"].ToString(),
                            };
                        }
                        var hasFeedback = !reader.IsNull("id");

                        if (hasFeedback)
                        {
                            model.Feedback.Add(GetFeedback(reader));
                        }




                    }
                }
            }

            return model;
        }

        private Feedback GetFeedback(IDataReader reader)
        {
            return new Feedback
            {
                id = Convert.ToInt32(reader["id"]),
                rating = Convert.ToInt32(reader["rating"]),
                review = reader["review"].ToString(),
                product_id = Convert.ToInt32(reader["product_id"]),


            };
        }
    }
}
