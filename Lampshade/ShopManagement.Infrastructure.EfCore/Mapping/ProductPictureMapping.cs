using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PictureName).IsRequired();
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(1000).IsRequired();

            builder.HasOne(p => p.Product).
                WithMany(p => p.ProductPictures).
                HasForeignKey(f => f.ProductId);
        }
    }
}
