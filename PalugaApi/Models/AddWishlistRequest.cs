using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalugaApi.Models
{
    public class AddWishlistRequest
    {
        public string BookISBN10 { get; set; }
        public string BookISBN13 { get; set; }
    }
}
