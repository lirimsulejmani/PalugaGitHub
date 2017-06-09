using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel;
using PalugaApi.Infrastructure;
using PalugaApi.Models;
using ServiceLayer.Contracts;
using ServiceLayer.DTO;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudentController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService, IMapper mapper) : base(studentService)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [NoCache]
        [HttpPut("update-profile/{id}")]
        public IActionResult UpdateProfile(Guid id, [FromBody]UpdateProfileRequest model)
        {
            var profile = _mapper.Map<UpdateProfileDto>(model);
            try
            {
                _studentService.UpdateProfile(profile);
                return RespondSuccess("Profile updated successfully.");
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }
    }
}