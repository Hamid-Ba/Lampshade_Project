using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Message).HasMaxLength(500).IsRequired();

            builder.HasOne(p => p.Parent).
                WithMany(c => c.Children).
                HasForeignKey(f => f.ParentId);
        }
    }
}
