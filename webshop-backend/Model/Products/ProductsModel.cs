﻿namespace webshop_backend.Model.Products
{
	public class ProductsModel
	{
		public int id { get; set; }
		public string name { get; set; }

		public string description { get; set; }
		public int price { get; set; }

		public int quantity { get; set; }
		public int category_id { get; set; }
	
	
	}
}

