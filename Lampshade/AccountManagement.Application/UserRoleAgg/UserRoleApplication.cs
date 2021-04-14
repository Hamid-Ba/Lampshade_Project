using AccountManagement.Application.Contract.UserRoleAgg;
using AccountManagement.Domain.UserRoleAgg;
using Framework.Application;

namespace AccountManagement.Application.UserRoleAgg
{
    public class UserRoleApplication : IUserRoleApplication
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleApplication(IUserRoleRepository userRoleRepository) => _userRoleRepository = userRoleRepository;

        public OperationResult AddRolesToUser(long userId, long[] RolesId)
        {
            OperationResult result = new OperationResult();

            if (userId <= 0 || RolesId.Length == 0) return result.Failed("نقشی انتخاب نشده است!");

            var previousUserRoles = _userRoleRepository.GetAll();

            foreach (var userRole in previousUserRoles) if (userRole.UserId == userId) _userRoleRepository.DeleteEntity(userRole);

            foreach (var roleId in RolesId)
            {
                var userRole = new UserRole(userId, roleId);
                _userRoleRepository.Create(userRole);
            }

            _userRoleRepository.SaveChanges();
            return result.Succeeded();
        }
    }
}
