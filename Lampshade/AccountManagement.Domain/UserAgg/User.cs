using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserRoleAgg;
using Framework.Domain;
using System.Collections.Generic;

namespace AccountManagement.Domain.UserAgg
{
    public class User : EntityBaseModel
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string Picture { get; private set; }

        public List<UserRole> UserRoles { get; private set; }

        public User(string fullname, string username, string email, string password, string mobile, string picture)
        {
            Fullname = fullname;
            Username = username;
            Email = email;
            Password = password;
            Mobile = mobile;
            Picture = picture;
        }

        public void Edit(string fullname, string username, string email, string mobile, string picture)
        {
            Fullname = fullname;
            Username = username;
            Email = email;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            Mobile = mobile;
        }

        public void ChangePassword(string password) => Password = password;

        public void Delete() => IsDeleted = true;
    }
}
