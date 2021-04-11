using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Name = r.Name
        }).ToList();

        public EditRoleVM GetDetailForEdit(long id) => _context.Roles.Select(r => new EditRoleVM()
        {
            Id = r.Id,
            Name = r.Name
        }).FirstOrDefault(r => r.Id == id);


        public DeleteRoleVM GetDetailForDelete(long id) => _context.Roles.Select(r => new DeleteRoleVM()
        {
            Id = r.Id,
            Name = r.Name
        }).FirstOrDefault(r => r.Id == id);
    }
}
