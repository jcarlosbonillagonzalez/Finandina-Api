using System.Linq.Expressions;

namespace Finandina_Application.Specifications.Common
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = new ReplaceExpressionVisitor()
                .Replace(expr1.Parameters[0], parameter)
                .Replace(expr2.Parameters[0], parameter)
                .Visit(Expression.AndAlso(expr1.Body, expr2.Body))!;

            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }

        private sealed class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Dictionary<Expression, Expression> _replacements = new();

            public ReplaceExpressionVisitor Replace(Expression original, Expression replacement)
            {
                _replacements[original] = replacement;
                return this;
            }

            public override Expression? Visit(Expression? node)
            {
                return node != null && _replacements.TryGetValue(node, out var replacement)
                    ? replacement
                    : base.Visit(node);
            }
        }
    }
}
