using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DTO;
using PalugaApi.Infrastructure;
using PalugaApi.Models;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SignUpController : ApiController
    {
        private readonly IStudentService _studentService;
        private readonly IMailService _mailService;
        private readonly ISecurityService _securityService; 

        public SignUpController(IStudentService studentService, IMailService mailService, ISecurityService securityService) : base(studentService)
        {
            _studentService = studentService;
            _mailService = mailService;
            _securityService = securityService;
        }


        // POST: api/signup
        [NoCache]
        [HttpPost]
        public async Task<IActionResult> Post(SignUpRequest model)
        {
            if (string.IsNullOrEmpty(model.Email))
                return BadRequest();

            var existingStudent = _studentService.GetByEmail(model.Email);
            if (existingStudent != null)
            {
                if(!existingStudent.Active || existingStudent.Deleted){
                    await _mailService.SignUpMail(existingStudent.Email, existingStudent.ApiToken);
                    return Respond(existingStudent);
                }
                return RespondWithError("Email already exists.", 422);
            }

            var user = new CreateStudentDto()
            {
                Name = model.Name,
                Email = model.Email,
                SchoolId = model.School
            };

            var id = await _studentService.CreateAsync(user);
            if (string.IsNullOrEmpty(id.ToString()))
                return RespondWithError("Error while saving student!", 422);

            var student = await _studentService.GetById(id);
            await _mailService.SignUpMail(student.Email, student.ApiToken);
            return Respond(student);
        }

        [HttpGet("[action]/{token}")]
        public IActionResult Verify(string token)
        {
            if (string.IsNullOrEmpty(token))
                return RespondBadRequest();

            var student = _studentService.GetByToken(token);
            if (student == null)
                return RespondBadRequest();

            return Respond(student);
        }

        // POST: api/signup
        [NoCache]
        [HttpPost("[action]")]
        public IActionResult Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return RespondWithError(ModelState.Values.First().Errors.First().ErrorMessage, 422);

            var student = _studentService.GetByTokenAndEmail(model.Token, model.Email);
            if (student == null)
                return RespondBadRequest();

            student.Password = _securityService.Encrypt(model.Password);
            _studentService.Activate(student);

            return RespondSuccess("User registered successfuly");
        }

    }
}
