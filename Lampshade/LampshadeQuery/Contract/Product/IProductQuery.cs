using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.Product
{
    public interface IProductQuery
    {
        IEnumerable<ProductQueryVM> GetLatestArrival(int count);
        IEnumerable<ProductQueryVM> Search(string search);
    }
}
