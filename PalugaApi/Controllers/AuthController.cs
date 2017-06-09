using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PalugaApi.Models;
using PalugaApi.Infrastructure;
using ServiceLayer.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {
        private readonly IMapper _mapper;
        public AuthController(IStudentService studentService, IMapper mapper) : base(studentService)
        {
            _mapper = mapper;
        }

        [NoCache]
        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> Get()
        {
            var student = await AuthUser();
            var response = _mapper.Map<StudentViewModel>(student);
            return Respond(response);
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
