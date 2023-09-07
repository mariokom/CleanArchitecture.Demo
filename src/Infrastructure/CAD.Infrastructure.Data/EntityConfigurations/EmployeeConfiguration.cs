using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(256);
            builder.Property(s => s.EmployeeType);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
