using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Authentication
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public bool KeepMe { get; set; }
        public AuthViewModel() { }
        public AuthViewModel(long id, string fullname, string username, string mobile, bool keepMe)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            KeepMe = keepMe;
        }
    }
}
