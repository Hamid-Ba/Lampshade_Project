using AccountManagement.Domain.RolePermissionAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class RolePermissionMapping : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(k => new { k.RoleId, k.PermissionId });

            builder.HasOne(r => r.Role)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(f => f.RoleId);

            builder.HasOne(r => r.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(f => f.PermissionId);
        }
    }
}
