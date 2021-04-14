using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UserRoleAgg
{
    public interface IUserRoleApplication
    {
        OperationResult AddRolesToUser(long userId, long[] RolesId);
    }
}
