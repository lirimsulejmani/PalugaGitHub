using System;

namespace ServiceLayer.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string ApiToken { get; set; }

        public Guid SchoolId { get; set; }

        public string AcademicDiscipline { get; set; }

        public Guid EducationDegreeId { get; set; }

        public bool IsFullTime { get; set; }

        public string StudyCourse { get; set; }
    }
}
