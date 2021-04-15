using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace AccountManagement.Application.Contract.RoleAgg
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRoleVM command);
        OperationResult Edit(EditRoleVM command);
        EditRoleVM GetDetailForEdit(long id);
        IEnumerable<AdminRoleVM> GetAllForAdmin();
        bool IsRoleHasThePermission(long roleId, long permissionId);
    }
}
