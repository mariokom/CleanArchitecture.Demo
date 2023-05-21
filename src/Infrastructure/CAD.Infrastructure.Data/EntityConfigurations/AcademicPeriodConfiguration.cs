using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class AcademicPeriodConfiguration : IEntityTypeConfiguration<AcademicPeriod>
    {
        public void Configure(EntityTypeBuilder<AcademicPeriod> builder)
        {
            builder.HasKey(ac => ac.Id);
            builder.Property(ac => ac.Id).ValueGeneratedOnAdd();
            builder.Property(ac => ac.Name).IsRequired().HasMaxLength(200);

            builder.HasMany(ac => ac.CourseSections)
                .WithOne(cs => cs.AcademicPeriod)
                .HasForeignKey(cs => cs.AcademicPeriodId);
        }
    }
}
