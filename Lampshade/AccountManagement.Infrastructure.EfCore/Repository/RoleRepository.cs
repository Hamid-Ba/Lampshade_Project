using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Domain.RoleAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public EditRoleVM GetDetailForEdit(long id)
        {
            var query = _context.Roles.Select(r => new EditRoleVM()
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).FirstOrDefault(r => r.Id == id);

            query.PermissionsId = _context.RolePermissions.Where(r => r.RoleId == query.Id).Select(p => p.PermissionId).ToArray();

            return query;
        }

        public Role GetRoleWithPermissions(long id) => _context.Roles.Include(r => r.RolePermissions).ThenInclude(p => p.Permission).FirstOrDefault(r => r.Id == id);

    }
}
