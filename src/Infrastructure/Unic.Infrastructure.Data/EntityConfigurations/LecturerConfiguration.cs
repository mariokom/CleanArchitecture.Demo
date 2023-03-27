using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unic.Domain.Entities;

namespace Unic.Infrastructure.Data.EntityConfigurations
{
    public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.HasKey(lec => lec.Id);
            builder.Property(lec => lec.Id).ValueGeneratedOnAdd();
            builder.Property(lec => lec.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(lec => lec.LastName).IsRequired().HasMaxLength(200);
            builder.Property(lec => lec.Email).IsRequired().HasMaxLength(256);
            builder.Property(lec => lec.Phone).IsRequired().HasMaxLength(50);
            builder.Property(lec => lec.SocialInsuranceNumber).IsRequired().HasMaxLength(50);

            builder.HasMany(lec => lec.CourseSectionLecturers)
                .WithOne(c => c.Lecturer)
                .HasForeignKey(c => c.LecturerId);

            builder.HasOne(s => s.SystemUser)
                .WithOne()
                .HasForeignKey<Lecturer>(s => s.SystemUserId);
        }
    }
}
