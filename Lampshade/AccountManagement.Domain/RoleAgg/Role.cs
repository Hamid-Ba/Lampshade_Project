using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.UserAgg;
using Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBaseModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<User> Users { get; private set; }

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

        public void Delete() => IsDeleted = true;
    }
}
