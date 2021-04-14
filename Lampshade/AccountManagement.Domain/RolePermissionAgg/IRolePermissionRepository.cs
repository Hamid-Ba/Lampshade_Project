using Framework.Domain;

namespace AccountManagement.Domain.RolePermissionAgg
{
    public interface IRolePermissionRepository : IRepository<long, RolePermission>
    {
    }
}
