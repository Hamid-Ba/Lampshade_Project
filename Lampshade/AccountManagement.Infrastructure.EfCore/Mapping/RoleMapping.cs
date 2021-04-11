using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(u => u.Users).WithOne(r => r.Role).HasForeignKey(f => f.RoleId);
        }
    }
}
