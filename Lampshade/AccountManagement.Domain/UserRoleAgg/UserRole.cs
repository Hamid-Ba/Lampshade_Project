using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;

namespace AccountManagement.Domain.UserRoleAgg
{
    public class UserRole
    {
        public long UserId { get; private set; }
        public long RoleId { get; private set; }

        public User User { get; private set; }
        public Role Role { get; private set; }

        public UserRole(long userId,long roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public void Edit(long userId, long roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
