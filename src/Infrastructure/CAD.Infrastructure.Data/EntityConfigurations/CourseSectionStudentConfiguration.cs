using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class CourseSectionStudentConfiguration : IEntityTypeConfiguration<CourseSectionStudent>
    {
        public void Configure(EntityTypeBuilder<CourseSectionStudent> builder)
        {
            builder.HasKey(sectionLecturer => new { sectionLecturer.StudentlId, sectionLecturer.CourseSectionId });

            builder.HasOne(sectionLecturer => sectionLecturer.Student)
                .WithMany(lecturer => lecturer.CourseSectionStudents)
                .HasForeignKey(sectionLecturer => sectionLecturer.StudentlId);

            builder.HasOne(sectionLecturer => sectionLecturer.CourseSection)
                .WithMany(section => section.CourseSectionStudents)
                .HasForeignKey(sectionLecturer => sectionLecturer.CourseSectionId);
        }
    }
}
