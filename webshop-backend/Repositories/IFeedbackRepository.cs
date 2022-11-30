<<<<<<< HEAD
﻿using webshop_backend.Model;

namespace webshop_backend.Repositories
{
	public interface IFeedbackRepository
	{
        void createFeedback(int id, string review, int rating, int product_id);
        IList<Feedback> GetFeedback();
      

    }
}

=======
﻿namespace webshop_backend.Repositories
{
    public interface IFeedbackRepository
    {
    }
}
>>>>>>> master
