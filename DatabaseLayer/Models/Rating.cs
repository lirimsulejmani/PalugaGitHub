using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseLayer.Models
{
    public class Rating : BaseEntity
    {
        public Student Student { get; set; }

        public int Stars { get; set; }

        [MaxLength(5000)]
        public string Comment { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
