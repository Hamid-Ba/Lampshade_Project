using AccountManagement.Domain.RolePermissionAgg;
using Framework.Domain;
using System.Collections.Generic;

namespace AccountManagement.Domain.PermissionAgg
{
    public class Permission 
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public long? ParentId { get; private set; }
        
        public List<RolePermission> RolePermissions { get; private set; }
    }
}
