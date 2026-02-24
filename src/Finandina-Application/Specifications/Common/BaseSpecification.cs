using System.Linq.Expressions;
using Finandina_Domain.Interface;

namespace Finandina_Application.Specifications.Common
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification() { }

        protected BaseSpecification(Expression<Func<T, bool>> criteria) =>
            Criteria = criteria;

        public Expression<Func<T, bool>>? Criteria { get; protected set; }

        private readonly List<Expression<Func<T, object>>> _includes = new();
        public IReadOnlyList<Expression<Func<T, object>>> Includes => _includes;

        protected void AddInclude(Expression<Func<T, object>> include) =>
            _includes.Add(include);

        private readonly List<(Expression<Func<T, object>> Include,
                               Expression<Func<object, object>> ThenInclude)> _thenIncludes = new();
        public IReadOnlyList<(Expression<Func<T, object>> Include,
                              Expression<Func<object, object>> ThenInclude)> ThenIncludes => _thenIncludes;

        protected void AddThenInclude(Expression<Func<T, object>> include,
                                      Expression<Func<object, object>> thenInclude) =>
            _thenIncludes.Add((include, thenInclude));

        public Expression<Func<T, object>>? OrderBy { get; private set; }
        public Expression<Func<T, object>>? OrderByThen { get; private set; }
        public Expression<Func<T, object>>? OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> expr) => OrderBy = expr;
        protected void AddOrderByThen(Expression<Func<T, object>> expr) => OrderByThen = expr;
        protected void AddOrderByDesc(Expression<Func<T, object>> expr) => OrderByDesc = expr;

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        public bool IsTrackingDisabled { get; private set; }
        protected void ApplyNoTracking() => IsTrackingDisabled = true;
    }
}
