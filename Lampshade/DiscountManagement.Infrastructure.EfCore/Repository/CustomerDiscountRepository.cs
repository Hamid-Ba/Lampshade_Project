using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public IEnumerable<AdminCustomerDiscountVM> GetAllForAdmin(SearchCustomerDiscountVM search)
        {
            var discounts = _context.CustomerDiscounts.Select(c => new AdminCustomerDiscountVM()
            {
                Id = c.Id,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate,
                Reason = c.Reason,
                EndDate = c.EndDate.ToFarsi(),
                EndDateGr = c.EndDate,
                ProductName = _shopContext.Products.FirstOrDefault(p => p.Id == c.ProductId).Name,
                StartDate = c.StartDate.ToFarsi(),
                StartDateGr = c.StartDate
            });

            if (search.ProductId > 0) discounts = discounts.Where(c => c.ProductId == search.ProductId);
            if (!string.IsNullOrWhiteSpace(search.StartDate))
                discounts = discounts.Where(c => c.StartDateGr > search.StartDate.ToGeorgianDateTime());
            if (!string.IsNullOrWhiteSpace(search.EndDate))
                discounts = discounts.Where(c => c.EndDateGr < search.EndDate.ToGeorgianDateTime());

            return discounts.ToList();
        }

        public EditCustomerDiscountVM GetDetailForEdit(long id) => _context.CustomerDiscounts.Where(c => c.Id == id)
            .Select(c => new EditCustomerDiscountVM()
            {
                DiscountRate = c.DiscountRate,
                EndDate = c.EndDate.ToFarsi(),
                Id = c.Id,
                ProductId = c.ProductId,
                Reason = c.Reason,
                StartDate = c.StartDate.ToFarsi()
            }).FirstOrDefault();

        public DeleteCustomerDiscountVM GetDetailForDelete(long id) => _context.CustomerDiscounts.Where(c => c.Id == id)
            .Select(c => new DeleteCustomerDiscountVM()
            {
                DiscountRate = c.DiscountRate,
                Id = c.Id,
                ProductId = c.ProductId,
                ProductName = _shopContext.Products.FirstOrDefault(p => p.Id == c.ProductId).Name
            }).FirstOrDefault();
    }
}