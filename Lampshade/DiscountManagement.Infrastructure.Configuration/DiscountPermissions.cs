using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.Configuration
{
   public static class DiscountPermissions
    {
        public static int DiscountManagement { get; private set; } = 13;
        public static int UserDiscount { get; private set; } = 39;
        public static int CreateUserDiscount { get; private set; } = 40;
        public static int EditUserDiscount { get; private set; } = 41;
        public static int DeleteUserDiscount { get; private set; } = 42;
        public static int ColleagueDiscount { get; private set; } = 43;
        public static int CreateColleagueDiscount { get; private set; } = 44;
        public static int EditColleagueDiscount { get; private set; } = 45;
        public static int DeleteColleagueDiscount { get; private set; } = 46;
    }
}
