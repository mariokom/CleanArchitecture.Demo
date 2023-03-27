namespace Unic.Core.Shared.Models
{
    public class CourseModel
    {
        public string CourseSectionTitle { get; set; } = string.Empty;
        public List<LecturerModel> Lecturers { get; set; }
        public int? TotalStudents { get; set; } = null;
    }
}
