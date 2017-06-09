using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Query();
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include);
        Guid Add(T item);
        void Update(T update);
        void Delete(Guid id);
    }
}
