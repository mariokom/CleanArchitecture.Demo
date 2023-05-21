namespace CAD.Domain.Entities
{
    public class CourseSectionStudent
    {
        public int StudentlId { get; set; }
        public int CourseSectionId { get; set; }

        public Student Student { get; set; }
        public CourseSection CourseSection { get; set; }
    }
}
