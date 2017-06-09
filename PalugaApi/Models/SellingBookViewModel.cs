using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalugaApi.Models
{
    public class SellingBookViewModel
    {
        //public string StudentId { get; set; }
        public string BookId { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public int? BookConditionId { get; set; }    
        
        public decimal? Price { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }
        
    }
}
