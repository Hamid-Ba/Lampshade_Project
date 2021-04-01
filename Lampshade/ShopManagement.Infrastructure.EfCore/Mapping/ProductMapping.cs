using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Code).HasMaxLength(15);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.Keywords).HasMaxLength(200).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(150);
            builder.Property(p => p.PictureTitle).HasMaxLength(250);
            builder.Property(p => p.ShortDescription).HasMaxLength(500);
            builder.Property(p => p.Slug).HasMaxLength(400).IsRequired();

            builder.HasOne(p => p.Category).
                WithMany(c => c.Products).
                HasForeignKey(f => f.CategoryId);

            builder.HasMany(p => p.ProductPictures).
                WithOne(p => p.Product).
                HasForeignKey(f => f.ProductId);

            builder.HasMany(c => c.Comments).
                WithOne(p => p.Product).
                HasForeignKey(f => f.ProductId);
        }
    }
}
