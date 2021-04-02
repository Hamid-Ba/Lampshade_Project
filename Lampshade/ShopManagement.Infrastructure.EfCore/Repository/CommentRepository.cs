using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.CommentAgg;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _context;

        public CommentRepository(ShopContext context) : base(context) => _context = context;

        public DeleteCommentVM GetDetailForDelete(long id) => _context.Comments.Include(p => p.Product).Select(c => new DeleteCommentVM()
        {
            Id = c.Id,
            Name = c.Name,
            ProductId = c.ProductId,
            ProductName = c.Product.Name
        }).FirstOrDefault(c => c.Id == id);

        public IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search)
        {
            var query = _context.Comments.Include(p => p.Product).Select(c => new AdminCommentVM()
            {
                Id = c.Id,
                ProductName = c.Product.Name,
                ProductId = c.ProductId,
                Name = c.Name,
                CreationDate = c.CreationTime.ToFarsi(),
                Email = c.Email,
                IsConfirmed = c.IsConfirmed,
                Message = c.Message
            }).AsNoTracking();

            if (search.ProductId > 0) query = query.Where(p => p.ProductId == search.ProductId);
            if (!string.IsNullOrWhiteSpace(search.Email)) query = query.Where(c => c.Email.Contains(search.Email));

            return query.ToList();
        }
    }
}
