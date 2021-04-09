using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore.Mapping;

namespace CommentManagement.Infrastructure.EfCore
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
