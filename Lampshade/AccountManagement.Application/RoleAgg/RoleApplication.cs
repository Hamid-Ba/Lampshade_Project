using System.Collections.Generic;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Domain.RoleAgg;
using Framework.Application;

namespace AccountManagement.Application.RoleAgg
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public OperationResult Create(CreateRoleVM command)
        {
            OperationResult result = new OperationResult();

            if (_roleRepository.IsExist(r => r.Name == command.Name))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var role = new Role(command.Name, command.Description);
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();

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

            return result.Succeeded();
        }

        public EditRoleVM GetDetailForEdit(long id) => _roleRepository.GetDetailForEdit(id);

        public IEnumerable<AdminRoleVM> GetAllForAdmin() => _roleRepository.GetAllForAdmin();

    }
}
