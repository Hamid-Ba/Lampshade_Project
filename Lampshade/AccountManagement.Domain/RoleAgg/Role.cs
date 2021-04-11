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

        public List<User> Users { get; private set; }

        public Role(string name)
        {
            Name = name;
        }

        public void Edit(string name) => Name = name;

        public void Delete() => IsDeleted = true;
    }
}
