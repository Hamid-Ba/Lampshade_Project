using AccountManagement.Application.Contract.PermissionAgg;
using AccountManagement.Domain.PermissionAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.PermissionAgg
{
    public class PermissionApplication : IPermissionApplication
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionApplication(IPermissionRepository permissionRepository) => _permissionRepository = permissionRepository;

        public IEnumerable<AdminPermissionVM> GetAllForAdmin() => _permissionRepository.GetAllForAdmin();
        
    }
}
