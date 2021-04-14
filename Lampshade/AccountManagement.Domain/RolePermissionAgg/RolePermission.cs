using AccountManagement.Domain.PermissionAgg;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RolePermissionAgg
{
    public class RolePermission
    {
        public long RoleId { get; private set; }
        public long PermissionId { get; private set; }

        public Role Role { get; private set; }
        public Permission Permission { get; private set; }

        public RolePermission(long roleId,long permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
