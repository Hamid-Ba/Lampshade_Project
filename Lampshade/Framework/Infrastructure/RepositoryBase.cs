using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context) => _context = context;

        public void Create(T entity) => _context.Add(entity);

        public T Get(TKey id) => _context.Find<T>(id);

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public bool IsExist(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);

        public void SaveChanges() => _context.SaveChanges();
    }
}