using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unic.Domain.Entities;

namespace Unic.Infrastructure.Data.EntityConfigurations
{
    public class CourseSectionConfiguration : IEntityTypeConfiguration<CourseSection>
    {
        public void Configure(EntityTypeBuilder<CourseSection> builder)
        {
            builder.HasKey(css => css.Id);
            builder.Property(css => css.Id).ValueGeneratedOnAdd();
            builder.Property(css => css.SectionTitle).IsRequired().HasMaxLength(200);

            builder.HasOne(css => css.AcademicPeriod)
                .WithMany(ac => ac.CourseSections)
                .HasForeignKey(css => css.AcademicPeriodId);

            builder.HasOne(css => css.Course)
                .WithMany(c => c.CourseSections)
                .HasForeignKey(css => css.CourseId);
        }
    }
}
