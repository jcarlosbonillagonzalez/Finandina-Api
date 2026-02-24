using Finandina_Domain.Common;
using Finandina_Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Finandina_Persistence.Specifications
{
    public static class SpecificationEvaluator<T> where T : AuditableEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if (spec.IsTrackingDisabled)
                inputQuery = inputQuery.AsNoTracking();

            if (spec.Criteria != null)
                inputQuery = inputQuery.Where(spec.Criteria);

            if (spec.OrderBy != null && spec.OrderByThen != null)
                inputQuery = inputQuery.OrderBy(spec.OrderBy).ThenBy(spec.OrderByThen);
            else if (spec.OrderBy != null)
                inputQuery = inputQuery.OrderBy(spec.OrderBy);

            if (spec.OrderByDesc != null)
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDesc);

            if (spec.IsPagingEnabled)
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);

            foreach (var include in spec.Includes)
                inputQuery = inputQuery.Include(include);

            foreach (var thenInclude in spec.ThenIncludes)
                inputQuery = inputQuery.Include(thenInclude.Include)
                                      .ThenInclude(thenInclude.ThenInclude);

            return inputQuery;
        }
    }
}
