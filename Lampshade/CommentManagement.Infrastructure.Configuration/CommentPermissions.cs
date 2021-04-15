using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Infrastructure.Configuration
{
    public static class CommentPermissions
    {
        public static int CommentManagement { get; private set; } = 14;
        public static int CommentList { get; private set; } = 47;
        public static int ConfirmComment { get; private set; } = 48;
        public static int DeleteComment { get; private set; } = 49;
    }
}
