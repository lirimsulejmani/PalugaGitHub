using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class Comment : BaseEntity
    {
        public Student Student { get; set; }

        public string Body { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
