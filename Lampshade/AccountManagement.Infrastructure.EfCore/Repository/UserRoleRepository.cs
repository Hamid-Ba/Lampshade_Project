using AccountManagement.Domain.UserRoleAgg;
using Framework.Application;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class UserRoleRepository : RepositoryBase<long, UserRole>, IUserRoleRepository
    {
        private readonly AccountContext _accountContext;

        public UserRoleRepository(AccountContext accountContext) : base(accountContext) => _accountContext = accountContext;
    }
}
