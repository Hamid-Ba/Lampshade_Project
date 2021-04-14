using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Domain.RoleAgg;
using Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context) : base(context) => _context = context;

        public IEnumerable<AdminRoleVM> GetAllForAdmin() => _context.Roles.Select(r => new AdminRoleVM()
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            CreationDate = r.CreationTime.ToFarsi()
        }).ToList();

        public EditRoleVM GetDetailForEdit(long id) => _context.Roles.Select(r => new EditRoleVM()
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description
        }).FirstOrDefault(r => r.Id == id);
    }
}
