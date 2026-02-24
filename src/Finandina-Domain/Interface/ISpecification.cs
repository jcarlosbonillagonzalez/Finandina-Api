using System.Linq.Expressions;

namespace Finandina_Domain.Interface
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }
        IReadOnlyList<Expression<Func<T, object>>> Includes { get; }
        IReadOnlyList<(Expression<Func<T, object>> Include, Expression<Func<object, object>> ThenInclude)> ThenIncludes { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByThen { get; }
        Expression<Func<T, object>>? OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
        bool IsTrackingDisabled { get; }
    }
}
