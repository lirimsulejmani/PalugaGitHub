using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalugaApi.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
