using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTO
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid SchoolId { get; set; }
    }
}
