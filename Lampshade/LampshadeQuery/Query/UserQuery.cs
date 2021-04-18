using AccountManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly AccountContext _accountContext;

        public UserQuery(AccountContext accountContext) => _accountContext = accountContext;

        public UserQueryVM GetUserBy(string userName) => _accountContext.Users.Where(u => u.Username == userName).Select(u => new UserQueryVM
        {
            Id = u.Id,
            Email = u.Email,
            Fullname = u.Fullname,
            Mobile = u.Mobile,
            Username = u.Username
        }).FirstOrDefault();

    }
}
