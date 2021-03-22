using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EfCore
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<CustomerDiscount>().HasQueryFilter(c => !c.IsDeleted);
        }

        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
    }
}
