using AccountManagement.Domain.UserRoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(k => new { k.UserId, k.RoleId });

            builder.HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(f => f.UserId);

            builder.HasOne(u => u.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(f => f.RoleId);
        }
    }
}
