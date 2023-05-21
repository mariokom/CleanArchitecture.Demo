using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.EntityConfigurations
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.Username).IsRequired().HasMaxLength(200);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(50);
            builder.Property(user => user.Role).IsRequired();
        }
    }
}
