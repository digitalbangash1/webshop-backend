using System;
using System.ComponentModel.DataAnnotations;

namespace webshop_backend.Model.Products
{
	public class DeleteProductModel
	{
        [Required]
        public int id { get; set; }
    }
}

