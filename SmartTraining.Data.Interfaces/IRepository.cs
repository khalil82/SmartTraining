using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartTraining.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes);
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
