using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using ServiceLayer.Contracts;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : ApiController
    {
        public ValuesController(IStudentService studentService) : base(studentService)
        {
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            var student = await AuthUser();

            string[] data = new string[] { "value1", "value2" };

            return Respond(data);

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
