using AccountManagement.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(p => p.Fullname).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Username).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(125).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(11);

            builder.HasOne(r => r.Role).WithMany(u => u.Users).HasForeignKey(f => f.RoleId);
        }
    }
}
