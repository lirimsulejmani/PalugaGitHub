using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext context;

        public GenericRepository(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            var set = include.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                (context.Set<T>(), (current, expression) => current.Include(expression));

            return await set.Where(predicate).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            var set = include.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                (context.Set<T>(), (current, expression) => current.Include(expression));

            return await set.SingleOrDefaultAsync(predicate);
        }

        public Guid Add(T item)
        {
            context.Set<T>().Add(item);
            return item.Id;
        }
        
        public void Update(T update)
        {
            context.Entry(update).State = EntityState.Modified;
        }

        public async void Delete(Guid id)
        {
            var item = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(item);
        }
    }
}
