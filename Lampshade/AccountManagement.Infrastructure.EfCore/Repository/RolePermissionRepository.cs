using AccountManagement.Domain.RolePermissionAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class RolePermissionRepository : RepositoryBase<long, RolePermission>, IRolePermissionRepository
    {
        private readonly AccountContext _accountContext;

        public RolePermissionRepository(AccountContext accountContext) : base(accountContext) => _accountContext = accountContext;
        
    }
}
