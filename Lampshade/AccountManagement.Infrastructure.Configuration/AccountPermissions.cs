using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.Configuration
{
    public static class AccountPermissions
    {
        public const int AccountManagement  = 16;
        public const int UserList  = 58;
        public const int CreateUser  = 59;
        public const int EditUser  = 60;
        public const int EditUserPassword  = 61;
        public const int DeleteUser  = 62;
        public const int RoleList  = 63;
        public const int CreateRole  = 64;
        public const int EditRole  = 65;
    }
}
