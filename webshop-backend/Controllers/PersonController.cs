/*using Microsoft.AspNetCore.Mvc;
using webshop_backend.Model;
using webshop_backend.Repositories;

namespace webshop_backend.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : BaseController
    {
        private readonly IPersonRespository personRespository;
        public PersonController(IPersonRespository personRespository)
        {
            this.personRespository = personRespository;

        }
        [HttpGet]
        public IList<Person> GetPersons()
        {
            return personRespository.GetPersons();
        }
    }
}
*/