using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalugaApi.Models
{
    public class SignUpRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid School { get; set; }
    }
}
