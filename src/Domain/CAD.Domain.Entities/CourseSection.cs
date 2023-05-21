namespace CAD.Domain.Entities
{
    public class CourseSection
    {
        public int Id { get; set; }
        public string SectionTitle { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public int AcademicPeriodId { get; set; }

        public Course Course { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }

        public ICollection<CourseSectionLecturer> CourseSectionLecturers { get; set; }
        public ICollection<CourseSectionStudent> CourseSectionStudents { get; set; }
    }
}
