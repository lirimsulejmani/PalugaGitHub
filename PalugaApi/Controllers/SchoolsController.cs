using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PalugaApi.Infrastructure;
using ServiceLayer.Contracts;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SchoolsController : ApiController
    {
        private readonly ISchoolService _schoolService;
        public SchoolsController(ISchoolService schoolService, IStudentService studentService) : base(studentService)
        {
            _schoolService = schoolService;
        }

        [NoCache]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var schools = await _schoolService.GetList();
            return Respond(schools);
        }

        [HttpGet("[action]")]
        public IActionResult Seed()
        {
            /* TODO - Use this when seeding initial data */
            _schoolService.SeedSchools();
            return Ok();
        }
    }
}