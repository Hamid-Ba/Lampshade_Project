using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.IssueTrackingNo).HasMaxLength(8);

            builder.OwnsMany(o => o.OrderItems, modelBuilder =>
            {
                modelBuilder.HasKey(i => i.Id);
                modelBuilder.WithOwner(i => i.Order).HasForeignKey(f => f.OrderId);
            });
        }
    }
}