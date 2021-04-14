using Framework.Application;

namespace AccountManagement.Application.Contract.RolePermissionAgg
{
    public interface IRolePermissionApplication
    {
        OperationResult AddPermissionsToRole(long roleId, long[] permissionsId);
    }
}
