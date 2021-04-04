using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(600).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Keywords).HasMaxLength(200).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(500).IsRequired();

            builder.HasMany(a => a.Articles).
                WithOne(c => c.ArticleCategory).
                HasForeignKey(f => f.CategoryId);
        }
    }
}
