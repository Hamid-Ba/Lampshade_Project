using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using _0_Framework.Application;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Domain.UserAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class UserRepository : RepositoryBase<long, User>, IUserRepository
    {
        private readonly AccountContext _context;
        public UserRepository(AccountContext context) : base(context) => _context = context;

        public EditUserVM GetDetailForEdit(long id) => _context.Users.Select(u => new EditUserVM()
        {
            Id = u.Id,
            Email = u.Email,
            Fullname = u.Fullname,
            Mobile = u.Mobile,
            Username = u.Username,
            RoleId = u.RoleId
        }).FirstOrDefault(u => u.Id == id);

        public DeleteUserVM GetDetailForDelete(long id) => _context.Users.Select(u => new DeleteUserVM()
        {
            Id = u.Id,
            Fullname = u.Fullname
        }).FirstOrDefault(u => u.Id == id);

        public IEnumerable<AdminUserVM> GetAllForAdmin(SearchUserVM search)
        {
            var query = _context.Users.Include(r => r.Role).Select(u => new AdminUserVM()
            {
                Id = u.Id,
                CreationDate = u.CreationTime.ToFarsi(),
                Picture = u.Picture,
                Email = u.Email,
                Fullname = u.Fullname,
                RoleId = u.RoleId,
                Mobile = u.Mobile,
                RoleName = u.Role.Name,
                Username = u.Username
            }).OrderByDescending(u => u.Id).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search.Username))
                query = query.Where(u => u.Username.Contains(search.Username));
            if (!string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(u => u.Email.Contains(search.Email));
            if (!string.IsNullOrWhiteSpace(search.Mobile))
                query = query.Where(u => u.Mobile.Contains(search.Mobile));
            if (search.RoleId > 0)
                query = query.Where(u => u.RoleId == search.RoleId);

            return query.ToList();
        }
    }
}
