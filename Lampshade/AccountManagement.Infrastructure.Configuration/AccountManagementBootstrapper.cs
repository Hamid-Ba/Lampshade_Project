using AccountManagement.Application.Contract.PermissionAgg;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Application.Contract.RolePermissionAgg;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Application.Contract.UserRoleAgg;
using AccountManagement.Application.PermissionAgg;
using AccountManagement.Application.RoleAgg;
using AccountManagement.Application.RolePermissionAgg;
using AccountManagement.Application.UserAgg;
using AccountManagement.Application.UserRoleAgg;
using AccountManagement.Domain.PermissionAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.RolePermissionAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserRoleAgg;
using AccountManagement.Infrastructure.EfCore;
using AccountManagement.Infrastructure.EfCore.Repository;
using LampshadeQuery.Contract.User;
using LampshadeQuery.Query;
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

            service.AddTransient<IUserRoleRepository, UserRoleRepository>();
            service.AddTransient<IUserRoleApplication, UserRoleApplication>();

            service.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            service.AddTransient<IRolePermissionApplication, RolePermissionApplication>();

            service.AddTransient<IPermissionRepository, PermissionRepository>();
            service.AddTransient<IPermissionApplication, PermissionApplication>();

            service.AddTransient<IUserQuery, UserQuery>();
        }
    }
}
