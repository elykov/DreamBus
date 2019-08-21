using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class DataBaseGenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        DreamBusContext context;
        IDbSet<T> dbSet;

        public DataBaseGenericRepository(DreamBusContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void AddOrUpdate(T obj)
        {
            try
            {
                dbSet.AddOrUpdate(obj);

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
