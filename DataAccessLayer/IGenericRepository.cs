using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IGenericRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void AddOrUpdate(T obj);
        void Delete(T obj);
        void Save();
    }
}
