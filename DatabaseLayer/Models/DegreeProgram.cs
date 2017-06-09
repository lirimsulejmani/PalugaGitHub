namespace DatabaseLayer.Models
{
    public class DegreeProgram : BaseEntity
    {
        public string Name { get; set; }

        public School School { get; set; }

        public EducationDegree EducationDegree { get; set; }
    }
}