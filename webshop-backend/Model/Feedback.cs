using System;
namespace webshop_backend.Model
{
	public class Feedback
	{
       

        public int id { get; set; }
        public string review { get; set; }
        public int rating { get; set; }
        public int product_id { get; set; }
    
	}
}

