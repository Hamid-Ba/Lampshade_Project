using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : EntityBaseModel
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Delete() => IsDeleted = true;
    }
}
