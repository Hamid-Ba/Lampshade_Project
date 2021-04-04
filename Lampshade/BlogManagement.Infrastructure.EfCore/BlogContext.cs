using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<ArticleCategory>().HasQueryFilter(c => !c.IsDeleted);
        }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
    }
}
