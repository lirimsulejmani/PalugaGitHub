using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class BookProviderClicksLog : BaseEntity
    {
        public string Name { get; set; }

        public Student Student { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
