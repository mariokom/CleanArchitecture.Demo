namespace CAD.Domain.Entities
{
    public class AcademicPeriod
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ICollection<CourseSection> CourseSections { get; set; }
    }
}
