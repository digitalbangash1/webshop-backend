using Microsoft.AspNetCore.Mvc;

using webshop_backend.Model;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    [ApiController]
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository FeedbackRespository;

        public FeedbackController(IFeedbackRepository FeedbackRepository)
        {
            this.FeedbackRespository = FeedbackRepository;

        }

        [HttpGet]
        public IActionResult GetFeedback()
        {
            return Ok(FeedbackRespository.GetFeedback());
        }


        [HttpPost]
        public IActionResult createCFeedback(Feedback model)
        {
            FeedbackRespository.createFeedback(model.id, model.review, model.rating, model.product_id);
            return Ok();
        }

       

    }
}




