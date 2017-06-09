using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTO
{
    public class SellingBookDto
    {
        public Guid StudentId { get; set; }
        public string BookId { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
      
        public int BookConditionId { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
    }
}
