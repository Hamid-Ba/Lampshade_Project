using Framework.Application;
using Framework.Domain;

namespace AccountManagement.Domain.UserRoleAgg
{
    public interface IUserRoleRepository : IRepository<long,UserRole>
    {
    }
}
