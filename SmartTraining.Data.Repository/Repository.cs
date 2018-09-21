using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SmartTraining.Data.EntityFramework;
using SmartTraining.Data.Interfaces;

namespace SmartTraining.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext Context;
        protected readonly DbSet<T> Dbset;

        public Repository(DataContext context)
        {
            Context = context;
            Dbset = context.Set<T>();
        }

        public T Find(int id)
        {
            return Dbset.Find(id);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Dbset.Where(predicate);
        }
        public IEnumerable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return Dbset.Where(predicate).AsNoTracking();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return Dbset.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset;
        }

        public IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Dbset;

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public IEnumerable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Dbset.Where(predicate);

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Dbset.AddRange(entities);
        }

        public void Remove(T entity)
        {
            Dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Dbset.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
