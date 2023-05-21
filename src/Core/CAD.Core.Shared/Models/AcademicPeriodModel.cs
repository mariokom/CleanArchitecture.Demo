namespace CAD.Core.Shared.Models
{
    public class AcademicPeriodModel
    {
        public string AcademicPeriod { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<CourseModel> Courses { get; set; }
    }
}
