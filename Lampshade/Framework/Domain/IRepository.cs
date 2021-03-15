using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IRepository<in TKey,T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(TKey id);
        void Create(T entity);
        bool IsExist(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
