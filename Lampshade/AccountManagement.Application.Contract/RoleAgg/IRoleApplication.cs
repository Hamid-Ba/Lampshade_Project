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
        OperationResult Delete(DeleteRoleVM command);
        EditRoleVM GetDetailForEdit(long id);
        DeleteRoleVM GetDetailForDelete(long id);
        IEnumerable<AdminRoleVM> GetAllForAdmin();
    }
}
