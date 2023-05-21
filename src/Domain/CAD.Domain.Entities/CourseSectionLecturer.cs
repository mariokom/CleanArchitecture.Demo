namespace CAD.Domain.Entities
{
    public class CourseSectionLecturer
    {
        public int LecturerId { get; set; }
        public int CourseSectionId { get; set; }

        public Lecturer Lecturer { get; set; }
        public CourseSection CourseSection { get; set; }
    }
}
