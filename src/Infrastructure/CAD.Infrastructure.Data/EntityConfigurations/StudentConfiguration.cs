using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(256);
            builder.Property(s => s.Phone).IsRequired().HasMaxLength(50);

            builder.HasMany(s => s.CourseSectionStudents)
                .WithOne(css => css.Student)
                .HasForeignKey(s => s.StudentlId);

            builder.HasOne(s => s.SystemUser)
                .WithOne()
                .HasForeignKey<Student>(s => s.SystemUserId);
        }
    }
}
