namespace Unic.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int SystemUserId { get; set; }

        public SystemUser SystemUser { get; set; }
        public ICollection<CourseSectionStudent> CourseSectionStudents { get; set; }
    }
}
