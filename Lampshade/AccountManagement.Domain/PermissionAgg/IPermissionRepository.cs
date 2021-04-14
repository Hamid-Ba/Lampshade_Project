using AccountManagement.Application.Contract.PermissionAgg;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.PermissionAgg
{
    public interface IPermissionRepository : IRepository<long,Permission>
    {
        IEnumerable<AdminPermissionVM> GetAllForAdmin();
    }
}
