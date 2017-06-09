namespace DatabaseLayer.Models
{
    public class StudyCourse : BaseEntity
    {
        public string Name { get; set; }

        public DegreeProgram DegreeProgram { get; set; }
    }
}