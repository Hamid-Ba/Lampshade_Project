using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EfCore
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
