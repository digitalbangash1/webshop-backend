﻿using webshop_backend.Model.Products;
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

        public void CreateProduct(string name, string description, decimal price, int quantity, string imageLink)
        {
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO product (name, description, price, quantity, imageLink) VALUES (@name, @description, @price, @quantity, @imageLink)";

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

                var imageLinkParam = cmd.CreateParameter();
                imageLinkParam.ParameterName = "@imageLink";
                imageLinkParam.Value = imageLink;
                cmd.Parameters.Add(imageLinkParam);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(int id, string name, string description, decimal price, int quantity, string imageLink)
        {
            using (var conn = dbConnectionService.Create())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE product SET name=@name, description=@description, price=@price, quantity=@quantity, imageLink=@imageLink WHERE id=@id";

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

                var imageLinkParam = cmd.CreateParameter();
                imageLinkParam.ParameterName = "@imageLink";
                imageLinkParam.Value = imageLink;
                cmd.Parameters.Add(imageLinkParam);

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
                imageLink = reader["imageLink"].ToString(),

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
    }
}