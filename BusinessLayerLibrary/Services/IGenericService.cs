using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayerLibrary.Services
{
    public interface IGenericService<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T obj);
        T Update(T obj);
        T Get(int id);
        T Delete(int id);
        void Save();
    }
}
