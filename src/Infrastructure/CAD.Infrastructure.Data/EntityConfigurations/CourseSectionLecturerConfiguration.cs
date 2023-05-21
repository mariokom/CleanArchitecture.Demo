using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class CourseSectionLecturerConfiguration : IEntityTypeConfiguration<CourseSectionLecturer>
    {
        public void Configure(EntityTypeBuilder<CourseSectionLecturer> builder)
        {
            builder.HasKey(sectionLecturer => new { sectionLecturer.LecturerId, sectionLecturer.CourseSectionId });

            builder.HasOne(sectionLecturer => sectionLecturer.Lecturer)
                .WithMany(lecturer => lecturer.CourseSectionLecturers)
                .HasForeignKey(sectionLecturer => sectionLecturer.LecturerId);

            builder.HasOne(sectionLecturer => sectionLecturer.CourseSection)
                .WithMany(section => section.CourseSectionLecturers)
                .HasForeignKey(sectionLecturer => sectionLecturer.CourseSectionId);
        }
    }
}
