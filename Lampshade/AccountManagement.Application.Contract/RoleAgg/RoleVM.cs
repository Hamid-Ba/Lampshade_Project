using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.RoleAgg
{
    public class CreateRoleVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long[] PermissionsId { get; set; }
    }

    public class EditRoleVM : CreateRoleVM
    {
        public long Id { get; set; }
    }

    public class AdminRoleVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
    }
}
