using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using CommentManagement.Application.Contract.CommentAgg;
using CommentManagement.Domain.CommentAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context) : base(context) => _context = context;

        public DeleteCommentVM GetDetailForDelete(long id) => _context.Comments.Select(c => new DeleteCommentVM()
        {
            Id = c.Id,
            Name = c.Name,
        }).FirstOrDefault(c => c.Id == id);

        public IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search)
        {
            var query = _context.Comments.Select(c => new AdminCommentVM()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationTime.ToFarsi(),
                Email = c.Email,
                IsConfirmed = c.IsConfirmed,
                Message = c.Message,
                OwnerId = c.OwnerId,
                Type = c.Type,
                OwnerName = c.OwnerName
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search.Name)) query = query.Where(c => c.Name.Contains(search.Name));
            if (!string.IsNullOrWhiteSpace(search.Email)) query = query.Where(c => c.Email.Contains(search.Email));

            return query.ToList();
        }
    }
}
