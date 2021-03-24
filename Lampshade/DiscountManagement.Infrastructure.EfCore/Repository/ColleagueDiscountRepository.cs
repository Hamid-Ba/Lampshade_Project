using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscountAgg;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public IEnumerable<AdminColleagueDiscountVM> GetAllForAdmin(SearchColleagueDiscountVM search)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();

            var query = _context.ColleagueDiscounts.Select(c => new AdminColleagueDiscountVM()
            {
                Id = c.Id,
                CreationDate = c.CreationTime.ToFarsi(),
                DiscountRate = c.DiscountRate,
                ProductId = c.ProductId,
            });

            if (search.ProductId > 0) query = query.Where(c => c.ProductId == search.ProductId);

            var discounts = query.ToList();

            discounts.ForEach(c => c.ProductName = products.Find(p => p.Id == c.ProductId)?.Name);

            return discounts;
        }

        public EditColleagueDiscountVM GetDetailForEdit(long id) => _context.ColleagueDiscounts.Where(c => c.Id == id).Select(c =>
            new EditColleagueDiscountVM()
            {
                Id = c.Id,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate
            }).FirstOrDefault();


        public DeleteColleagueDiscountVM GetDetailForDelete(long id)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();

            var discount = _context.ColleagueDiscounts.Select(c => new DeleteColleagueDiscountVM()
            {
                Id = c.Id,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate

            }).FirstOrDefault(c => c.Id == id);

            if (discount == null) return null;

            discount.ProductName = products.Find(p => p.Id == discount.ProductId)?.Name;
            return discount;
        }
    }
}