using System.Linq.Expressions;
using Finandina_Domain.Packager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Finandina_Persistence.Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        DbContext AppContext { get; set; }
        DbSet<T> Entity => AppContext.Set<T>();

        Task<int> AddAsync(List<T> values);
        Task<int> AddAsync(T value);

        Task<int> DeleteAsync(T value = null, Expression<Func<T, bool>> predicate = null);
        Task<int> DeleteAsync(List<T> values = null);

        Task<PagedResponse<T>> GetAllPaginatedAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> selector = null,
            BasicPaginationParams paginate = null
        );

        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> selector = null
        );

        Task<T> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, T>> selector = null
        );

        Task<int> UpdateAsync(List<T> values, params Expression<Func<T, object>>[] propertyExpressions);
        Task<int> UpdateAsync(T value, params Expression<Func<T, object>>[] propertyExpressions);
    }
}
