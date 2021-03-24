using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EfCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(k => k.Id);

            builder.OwnsMany(i => i.InventoryOperations, modelBuilder =>
            {
                modelBuilder.HasKey(k => k.Id);
                modelBuilder.Property(p => p.Description).HasMaxLength(500);
                modelBuilder.WithOwner(p => p.Inventory).HasForeignKey(f => f.InventoryId);
            });
        }
    }
}
