using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.RoleAgg;
using Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        IEnumerable<AdminRoleVM> GetAllForAdmin();
        EditRoleVM GetDetailForEdit(long id);
        Role GetRoleWithPermissions(long id);
    }
}
