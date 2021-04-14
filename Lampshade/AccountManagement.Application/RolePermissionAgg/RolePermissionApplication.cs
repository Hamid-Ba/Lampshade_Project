using AccountManagement.Application.Contract.RolePermissionAgg;
using AccountManagement.Domain.RolePermissionAgg;
using Framework.Application;

namespace AccountManagement.Application.RolePermissionAgg
{
    public class RolePermissionApplication : IRolePermissionApplication
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionApplication(IRolePermissionRepository rolePermissionRepository) => _rolePermissionRepository = rolePermissionRepository;

        public OperationResult AddPermissionsToRole(long roleId, long[] permissionsId)
        {
            OperationResult result = new OperationResult();

            if (roleId <= 0) return result.Failed();

            var previousRolePermissions = _rolePermissionRepository.GetAll();

            if (permissionsId != null)
            {
                foreach (var rolePermission in previousRolePermissions) if (rolePermission.RoleId == roleId) _rolePermissionRepository.DeleteEntity(rolePermission);

                foreach (var permissionId in permissionsId)
                {
                    if (permissionId == 0) continue;
                    var rolePermission = new RolePermission(roleId, permissionId);
                    _rolePermissionRepository.Create(rolePermission);
                }

                _rolePermissionRepository.SaveChanges();
            }

            return result.Succeeded();
        }
    }
}
