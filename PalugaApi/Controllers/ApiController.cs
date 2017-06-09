using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Security.Claims;
using ServiceLayer.Contracts;
using ServiceLayer.DTO;

namespace PalugaApi.Controllers
{
    public class ApiController : Controller
    {
        protected new HttpStatusCode StatusCode = HttpStatusCode.OK;
        private readonly IStudentService _studentService;

        public ApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public HttpStatusCode GetStatusCode()
        {
            return this.StatusCode;
        }

        public void SetStatusCode(HttpStatusCode code)
        {
            this.StatusCode = code;
        }

        public IActionResult Respond(object data)
        {
            var response = new JsonResult(new
            {
                data = data,
                statusCode = HttpStatusCode.OK
            }, DefaultJsonSettings);

            return response;
        }

        public IActionResult RespondNotFound(string message = "Not Found!")
        {
            var response = new JsonResult(new
            {
                error = message,
                statusCode = this.GetStatusCode()
            }) {StatusCode = (int) HttpStatusCode.NotFound};

            return response;
        }

        public IActionResult RespondWithError(string message, int code)
        {
            var response = new JsonResult(new
            {
                error = message,
                statusCode = code
            }) {StatusCode = code};

            return response;
        }

        public IActionResult RespondBadRequest(string message = "Bad request.")
        {
            var response = new JsonResult(new
            {
                error = message,
                statusCode = 400
            }) {StatusCode = 400};

            return response;
        }

        public IActionResult RespondCreated(string message)
        {
            var response = new JsonResult(new
            {
                Message = message,
                StatusCode = HttpStatusCode.Created
            }) {StatusCode = (int) HttpStatusCode.Created};

            return response;
        }

        public IActionResult RespondSuccess(string message)
        {
            var response = new JsonResult(new
            {
                Message = message,
                StatusCode = HttpStatusCode.OK
            }) {StatusCode = (int) HttpStatusCode.OK};

            return response;
        }

        protected JsonSerializerSettings DefaultJsonSettings => new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        };

        public async Task<StudentDto> AuthUser()
        {
            // The JWT "sub" claim is automatically mapped to ClaimTypes.NameIdentifier
            // by the UseJwtBearerAuthentication middleware           
            var userId = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            if(userId != null)
                return await _studentService.GetById(Guid.Parse(userId.Value));
            return null;
        }
    }
}
