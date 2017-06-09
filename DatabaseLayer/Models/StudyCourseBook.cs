using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class StudyCourseBook : BaseEntity
    {
        public Book Book { get; set; }

        public StudyCourse StudyCourse { get; set; }

    }
}
