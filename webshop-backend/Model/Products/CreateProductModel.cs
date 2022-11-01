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

        public string price { get; set; }

        public string quantity { get; set; }

    }
}

