using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ApiToken { get; set; }

        public virtual School School { get; set; }
        
        public string AcademicDiscipline { get; set; }

        public virtual EducationDegree EducationDegree { get; set; }

        public bool IsFullTime { get; set; }

        public string StudyCourse { get; set; }

        public bool Deleted { get; set; }

        public bool Active { get; set; }
    }
}
