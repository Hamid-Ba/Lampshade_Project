using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using _0_Framework.Application;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserRoleAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class UserRepository : RepositoryBase<long, User>, IUserRepository
    {
        private readonly AccountContext _context;
        public UserRepository(AccountContext context) : base(context) => _context = context;

        public EditUserVM GetDetailForEdit(long id)
        {
            var query = _context.Users.Select(u => new EditUserVM()
            {
                Id = u.Id,
                Email = u.Email,
                Fullname = u.Fullname,
                Mobile = u.Mobile,
                Username = u.Username,
            }).FirstOrDefault(u => u.Id == id);

            var userRoles = _context.UserRoles.Where(u => u.UserId == query.Id).ToList();

            if (userRoles.Count > 0)
            {
                query.RolesId = new List<long>();
                userRoles.ForEach(r => query.RolesId.Add(r.RoleId));
            }


            return query;
        }

        public DeleteUserVM GetDetailForDelete(long id) => _context.Users.Select(u => new DeleteUserVM()
        {
            Id = u.Id,
            Fullname = u.Fullname
        }).FirstOrDefault(u => u.Id == id);

        public User GetUserBy(string userName) => _context.Users.Include(r => r.UserRoles).ThenInclude(r => r.Role).FirstOrDefault(u => u.Username == userName);

        public IEnumerable<AdminUserVM> GetAllForAdmin(SearchUserVM search)
        {
            var query = _context.Users.Select(u => new AdminUserVM()
            {
                Id = u.Id,
                CreationDate = u.CreationTime.ToFarsi(),
                Picture = u.Picture,
                Email = u.Email,
                Fullname = u.Fullname,
                Mobile = u.Mobile,
                Username = u.Username
            }).OrderByDescending(u => u.Id).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search.Username))
                query = query.Where(u => u.Username.Contains(search.Username));
            if (!string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(u => u.Email.Contains(search.Email));
            if (!string.IsNullOrWhiteSpace(search.Mobile))
                query = query.Where(u => u.Mobile.Contains(search.Mobile));

            var result = query.ToList();

            result.ForEach(u => u.RoleName = GetRoleNameByUserId(u.Id).Item2);
            result.ForEach(u => u.RolesId = GetRoleNameByUserId(u.Id).Item1);

            if (search.RoleId > 0)
                result = result.Where(u => u.RolesId.Any(u => u == search.RoleId)).ToList();

            return result;
        }

        private (long[], string) GetRoleNameByUserId(long userId)
        {
            string allRolesName = "";

            var roles = _context.UserRoles.Where(u => u.UserId == userId).Include(r => r.Role).Select(r => new { r.RoleId, r.Role.Name }).ToList();
            var rolesId = new List<long>();

            for (int i = 0; i < roles.Count; i++)
            {
                if (roles.Count == i + 1)
                {
                    allRolesName += roles[i].Name;
                    break;
                }

                allRolesName += roles[i].Name + " , ";
            }

            foreach (var id in roles) rolesId.Add(id.RoleId);


            return (rolesId.ToArray(), allRolesName);
        }
    }
}
