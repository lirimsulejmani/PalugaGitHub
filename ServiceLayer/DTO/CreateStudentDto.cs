using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTO
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ApiToken { get; set; }
        public Guid SchoolId { get; set; }

        public CreateStudentDto()
        {
            ApiToken = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
        }
    }
}
