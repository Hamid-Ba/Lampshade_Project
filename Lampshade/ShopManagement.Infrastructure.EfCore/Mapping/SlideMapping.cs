using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.PictureName).IsRequired();
            builder.Property(s => s.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(s => s.PictureTitle).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.Header).HasMaxLength(225);
            builder.Property(s => s.Title).HasMaxLength(225);
            builder.Property(s => s.Text).HasMaxLength(500);
            builder.Property(s => s.BtnText).HasMaxLength(50);
        }
    }
}
