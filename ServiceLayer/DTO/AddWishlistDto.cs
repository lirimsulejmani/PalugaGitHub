using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTO
{
    public class AddWishlistDto
    {
        public string BookISBN10 { get; set; }
        public string BookISBN13 { get; set; }
        public Guid StudentId { get; set; }
    }
}
