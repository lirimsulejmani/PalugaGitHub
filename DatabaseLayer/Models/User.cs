using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public School School { get; set; }
    }
}
