using Application.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Business.Infrastructure
{
    public class RepositoryOrder<TSource> where TSource : Entity
    {
        private readonly OrderExpression _orderBy;

        private RepositoryOrder(OrderExpression orderBy)
        {
            _orderBy = orderBy;
        }

        public IQueryable<TSource> ApplyTo(IQueryable<TSource> queryable)
        {
            return _orderBy.Apply(queryable);
        }

        public RepositoryOrder<TSource> ThenBy<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression)
        {
            _orderBy.ThenBy(expression);
            return this;
        }

        public RepositoryOrder<TSource> ThenByDescending<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression)
        {
            _orderBy.ThenByDescending(expression);
            return this;
        }

        public static RepositoryOrder<TSource> OrderBy<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression)
        {
            var orderExpression = new OrderExpression<TOrderKey>(expression, false);
            return new RepositoryOrder<TSource>(orderExpression);
        }

        public static RepositoryOrder<TSource> OrderByDescending<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression)
        {
            var orderExpression = new OrderExpression<TOrderKey>(expression, true);
            return new RepositoryOrder<TSource>(orderExpression);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_orderBy);
        }

        private abstract class OrderExpression
        {
            public abstract IQueryable<TSource> Apply(IQueryable<TSource> queryable);
            public abstract IOrderedQueryable<TSource> Apply(IOrderedQueryable<TSource> queryable);
            public abstract void ThenBy<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression);
            public abstract void ThenByDescending<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression);
        }

        private class OrderExpression<TKey> : OrderExpression
        {
            private OrderExpression _thenBy;

            private readonly Expression<Func<TSource, TKey>> _orderBy;
            private readonly bool _descending;

            public OrderExpression(Expression<Func<TSource, TKey>> orderBy, bool descending)
            {
                _orderBy = orderBy;
                _descending = descending;
            }

            public override IQueryable<TSource> Apply(IQueryable<TSource> queryable)
            {
                var query = _descending ? queryable.OrderByDescending(_orderBy) : queryable.OrderBy(_orderBy);

                if (_thenBy != null)
                {
                    _thenBy.Apply(query);
                }

                return query;
            }

            public override IOrderedQueryable<TSource> Apply(IOrderedQueryable<TSource> queryable)
            {
                var query = _descending ? queryable.ThenByDescending(_orderBy) : queryable.ThenBy(_orderBy);

                if (_thenBy != null)
                {
                    _thenBy.Apply(query);
                }

                return query;
            }

            public override void ThenBy<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression)
            {
                if (_thenBy != null)
                {
                    _thenBy.ThenBy(expression);
                }
                else
                {
                    _thenBy = new OrderExpression<TOrderKey>(expression, false);
                }
            }

            public override void ThenByDescending<TOrderKey>(Expression<Func<TSource, TOrderKey>> expression)
            {
                if (_thenBy != null)
                {
                    _thenBy.ThenByDescending(expression);
                }
                else
                {
                    _thenBy = new OrderExpression<TOrderKey>(expression, true);
                }
            }

            public override int GetHashCode()
            {
#pragma warning disable RECS0025 // Non-readonly field referenced in 'GetHashCode()'
                return HashCode.Combine(_thenBy, _orderBy, _descending);
#pragma warning restore RECS0025 // Non-readonly field referenced in 'GetHashCode()'
            }
        }
    }


}
