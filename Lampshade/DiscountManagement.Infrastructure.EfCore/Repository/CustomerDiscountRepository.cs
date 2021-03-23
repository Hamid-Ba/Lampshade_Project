using System;
using System.Collections.Generic;
using System.Globalization;
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
            var products = _shopContext.Products.Select(p => new { Id = p.Id, Name = p.Name }).ToList();
            var query = _context.CustomerDiscounts.Select(c => new AdminCustomerDiscountVM()
            {
                Id = c.Id,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate,
                Reason = c.Reason,
                EndDate = c.EndDate.ToFarsi(),
                EndDateGr = c.EndDate,
                // ProductName = products.FirstOrDefault(p => p.Id == c.ProductId).Name,
                StartDate = c.StartDate.ToFarsi(),
                StartDateGr = c.StartDate,
                CreationDate = c.CreationTime.ToFarsi()
            }).AsQueryable();

            if (search.ProductId != 0) query = query.Where(x => x.ProductId == search.ProductId).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.StartDate))
            {
                query = query.Where(x => x.StartDateGr > search.StartDate.ToGeorgianDateTime()).AsQueryable();
            }

            if (!string.IsNullOrWhiteSpace(search.EndDate))
            {
                query = query.Where(x => x.EndDateGr < search.EndDate.ToGeorgianDateTime()).AsQueryable();
            }

            var discounts = query.ToList();

            foreach (var discount in discounts)
                discount.ProductName = products.Find(p => p.Id == discount.ProductId)?.Name;


            return discounts;
        }

        public EditCustomerDiscountVM GetDetailForEdit(long id) => _context.CustomerDiscounts.Where(c => c.Id == id)
            .Select(c => new EditCustomerDiscountVM()
            {
                DiscountRate = c.DiscountRate,
                EndDate = c.EndDate.ToString(CultureInfo.InvariantCulture),
                Id = c.Id,
                ProductId = c.ProductId,
                Reason = c.Reason,
                StartDate = c.StartDate.ToString(CultureInfo.InvariantCulture)
            }).FirstOrDefault();

        public DeleteCustomerDiscountVM GetDetailForDelete(long id)
        {
            var products = _shopContext.Products.Select(p => new { Id = p.Id, Name = p.Name }).ToList();

            var discount = _context.CustomerDiscounts.Where(c => c.Id == id)
                  .Select(c => new DeleteCustomerDiscountVM()
                  {
                      DiscountRate = c.DiscountRate,
                      Id = c.Id,
                      ProductId = c.ProductId,
                      //        ProductName = _shopContext.Products.FirstOrDefault(p => p.Id == c.ProductId).Name
                  }).FirstOrDefault();

            if (discount != null) { discount.ProductName = products.Find(p => p.Id == discount.ProductId)?.Name; }

            return discount;
        }
    }
}