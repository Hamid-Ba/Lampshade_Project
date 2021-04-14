using System.Collections.Generic;
using AccountManagement.Domain.UserRoleAgg;
using Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBaseModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<UserRole> UserRoles { get; private set; }

        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Edit(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
    }
}
