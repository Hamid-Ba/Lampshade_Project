using AccountManagement.Application.Contract.PermissionAgg;
using AccountManagement.Domain.PermissionAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class PermissionRepository : RepositoryBase<long, Permission>, IPermissionRepository
    {
        private readonly AccountContext _accountContext;

        public PermissionRepository(AccountContext accountContext) : base(accountContext) => _accountContext = accountContext;

        public IEnumerable<AdminPermissionVM> GetAllForAdmin() => _accountContext.Permissions.Select(p => new AdminPermissionVM
        {
            Id = p.Id,
            Name = p.Name,
            ParentId = p.ParentId
        }).AsNoTracking().ToList();

    }
}
