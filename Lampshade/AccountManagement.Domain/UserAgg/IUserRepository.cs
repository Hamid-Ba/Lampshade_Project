using System.Collections.Generic;
using AccountManagement.Application.Contract.UserAgg;
using Framework.Domain;

namespace AccountManagement.Domain.UserAgg
{
    public interface IUserRepository : IRepository<long, User>
    {
        EditUserVM GetDetailForEdit(long id);
        DeleteUserVM GetDetailForDelete(long id);
        User GetUserBy(string userName);
        IEnumerable<AdminUserVM> GetAllForAdmin(SearchUserVM search);
    }
}
