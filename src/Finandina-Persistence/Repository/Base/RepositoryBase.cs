using System.Linq.Expressions;
using Finandina_Domain.Packager;
using Finandina_Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Finandina_Persistence.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryBase(ApplicationContext context)
        {
            AppContext = context;
        }

        public DbContext AppContext { get; set; }
        public DbSet<T> Entity => AppContext.Set<T>();

        public async Task<int> AddAsync(List<T> values)
        {
            await Entity.AddRangeAsync(values);
            return await AppContext.SaveChangesAsync();
        }

        public async Task<int> AddAsync(T value)
        {
            await Entity.AddAsync(value);
            return await AppContext.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(T value = null, Expression<Func<T, bool>> predicate = null)
            => throw new NotImplementedException();

        public Task<int> DeleteAsync(List<T> values = null)
            => throw new NotImplementedException();

        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> selector = null)
        {
            var query = Entity.AsNoTracking();

            if (predicate != null) query = query.Where(predicate);
            if (include != null) query = include(query);

            if (orderBy != null)
            {
                if (selector != null)
                    return await orderBy(query).Select(selector).AsNoTracking().ToListAsync();

                return await orderBy(query).AsNoTracking().ToListAsync();
            }

            if (selector != null)
                return await query.Select(selector).AsNoTracking().ToListAsync();

            return await query.AsNoTracking().ToListAsync();
        }

        public Task<PagedResponse<T>> GetAllPaginatedAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> selector = null,
            BasicPaginationParams paginate = null)
            => throw new NotImplementedException();

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> selector = null)
        {
            var query = Entity.AsNoTracking();

            if (predicate != null) query = query.Where(predicate);
            if (include != null) query = include(query);

            if (orderBy != null)
            {
                if (selector != null)
                    return await orderBy(query).Select(selector).AsNoTracking().FirstOrDefaultAsync();

                return await orderBy(query).AsNoTracking().FirstOrDefaultAsync();
            }

            if (selector != null)
                return await query.Select(selector).AsNoTracking().FirstOrDefaultAsync();

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<int> UpdateAsync(List<T> values, params Expression<Func<T, object>>[] propertyExpressions)
            => throw new NotImplementedException();

        public Task<int> UpdateAsync(T value, params Expression<Func<T, object>>[] propertyExpressions)
            => throw new NotImplementedException();
    }
}
