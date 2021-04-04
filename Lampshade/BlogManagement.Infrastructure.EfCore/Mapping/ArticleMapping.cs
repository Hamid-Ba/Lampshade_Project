using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(600).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Keywords).HasMaxLength(200).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(p => p.PictureName).IsRequired();

            builder.HasOne(c => c.ArticleCategory).
                WithMany(a => a.Articles).
                HasForeignKey(f => f.CategoryId);
        }
    }
}
