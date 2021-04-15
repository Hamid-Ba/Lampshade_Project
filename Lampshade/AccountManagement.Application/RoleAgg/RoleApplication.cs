using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Application.Contract.RolePermissionAgg;
using AccountManagement.Domain.RoleAgg;
using Framework.Application;

namespace AccountManagement.Application.RoleAgg
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionApplication _rolePermissionApplication;
        public RoleApplication(IRoleRepository roleRepository, IRolePermissionApplication rolePermissionApplication)
        {
            _roleRepository = roleRepository;
            _rolePermissionApplication = rolePermissionApplication;
        }

        public OperationResult Create(CreateRoleVM command)
        {
            OperationResult result = new OperationResult();

            if (_roleRepository.IsExist(r => r.Name == command.Name))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var role = new Role(command.Name, command.Description);
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();

            _rolePermissionApplication.AddPermissionsToRole(role.Id, command.PermissionsId);

            return result.Succeeded();
        }

        public OperationResult Edit(EditRoleVM command)
        {
            OperationResult result = new OperationResult();

            var role = _roleRepository.Get(command.Id);

            if (role == null) return result.Failed(ValidateMessage.IsExist);

            if (_roleRepository.IsExist(r => r.Name == command.Name && r.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            role.Edit(command.Name, command.Description);
            _roleRepository.SaveChanges();

            _rolePermissionApplication.AddPermissionsToRole(role.Id, command.PermissionsId);

            return result.Succeeded();
        }

        public EditRoleVM GetDetailForEdit(long id) => _roleRepository.GetDetailForEdit(id);

        public IEnumerable<AdminRoleVM> GetAllForAdmin() => _roleRepository.GetAllForAdmin();

        public bool IsRoleHasThePermission(long roleId, long permissionId)
        {
            var role = _roleRepository.GetRoleWithPermissions(roleId);

            var permissions = role.RolePermissions.Select(p => p.PermissionId).ToList();

            foreach (var perId in permissions) if (perId == permissionId) return true;

            return false;
        }
    }
}
