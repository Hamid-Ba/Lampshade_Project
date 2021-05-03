using System.Collections.Generic;

namespace LampshadeQuery.Contract.Order
{
    public interface IOrderQuery
    {
        IEnumerable<(int, string)> GetUserOrdersStatusBy(string userName);
    }
}
