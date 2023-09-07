using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);

            builder.HasMany(c => c.Departments)
                .WithOne(d => d.Company)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
