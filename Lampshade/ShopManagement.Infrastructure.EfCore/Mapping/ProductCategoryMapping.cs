using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.KeyWords).HasMaxLength(100);
            builder.Property(c => c.PictureAlt).HasMaxLength(150);
            builder.Property(c => c.PictureTitle).HasMaxLength(250);
            builder.Property(c => c.MetaDescription).HasMaxLength(500);
            builder.Property(c => c.Slug).HasMaxLength(150).IsRequired();

            builder.HasMany(c => c.Products).
                WithOne(p => p.Category).
                HasForeignKey(c => c.CategoryId);
        }
    }
}
