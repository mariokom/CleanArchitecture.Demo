﻿namespace CAD.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public ICollection<CourseSection> CourseSections { get; set; }
    }
}
