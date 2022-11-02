using System;
using System.ComponentModel.DataAnnotations;

namespace webshop_backend.Model.Products
{
	public class CreateProductModel
	{
        [Required(ErrorMessage = "Required")]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

    }
}

