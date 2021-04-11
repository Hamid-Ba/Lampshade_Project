using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Application.RoleAgg;
using AccountManagement.Application.UserAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EfCore;
using AccountManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Infrastructure.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service, string connectionString)
        {
            #region ConfigDbContext

            service.AddDbContext<AccountContext>(a => a.UseSqlServer(connectionString));

            #endregion

            service.AddTransient<IRoleRepository, RoleRepository>();
            service.AddTransient<IRoleApplication, RoleApplication>();

            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IUserApplication, UserApplication>();
        }
    }
}
