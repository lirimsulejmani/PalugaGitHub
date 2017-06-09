using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DTO;
using Paluga.Infrastructure;

namespace Paluga.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SignUpController : Controller
    {
        protected StudentService studentService;
        public SignUpController(StudentService studentService) {
            this.studentService = studentService;
        }
                      

        // POST: api/signup
        [NoCache]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
                return BadRequest();

            var user = new CreateStudentDto() {
                Email = value
            };

            await this.studentService.CreateAsync(user);

            return new ContentResult();
        }
    }
}