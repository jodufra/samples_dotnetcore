using Application.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Business.Infrastructure
{
    public class RepositoryQuery<TSource> where TSource : Entity
    {
        private Expression<Func<TSource, bool>> _expression;

        public RepositoryQuery(Expression<Func<TSource, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public RepositoryQuery<TSource> And(Expression<Func<TSource, bool>> expression)
        {
            _expression = Compose(_expression, expression, Expression.And);

            return this;
        }

        public RepositoryQuery<TSource> Or(Expression<Func<TSource, bool>> expression)
        {
            _expression = Compose(_expression, expression, Expression.Or);

            return this;
        }

        public IQueryable<TSource> ApplyTo(IQueryable<TSource> queryable)
        {
            return queryable.Where(_expression);
        }

        public override int GetHashCode()
        {
#pragma warning disable RECS0025 // Non-readonly field referenced in 'GetHashCode()'
            return HashCode.Combine(_expression);
#pragma warning restore RECS0025 // Non-readonly field referenced in 'GetHashCode()'
        }

        public static implicit operator Expression<Func<TSource, bool>>(RepositoryQuery<TSource> repositoryQueryExpression)
        {
            return repositoryQueryExpression._expression;
        }

        public static explicit operator RepositoryQuery<TSource>(Expression<Func<TSource, bool>> expression)
        {
            return new RepositoryQuery<TSource>(expression);
        }

        private static Expression<TExpression> Compose<TExpression>(Expression<TExpression> left, Expression<TExpression> right, Func<Expression, Expression, Expression> merge)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            if (merge == null)
            {
                throw new ArgumentNullException(nameof(merge));
            }

            var map = left.Parameters.Select((f, i) => new { f, s = right.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterReplacerVisitor.ReplaceParameters(map, right.Body);

            return Expression.Lambda<TExpression>(merge(left.Body, secondBody), left.Parameters);
        }

        private class ParameterReplacerVisitor : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> map;

            public ParameterReplacerVisitor(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (map.TryGetValue(node, out var replacement))
                {
                    node = replacement;
                }

                return base.VisitParameter(node);
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterReplacerVisitor(map).Visit(exp);
            }
        }
    }
}
