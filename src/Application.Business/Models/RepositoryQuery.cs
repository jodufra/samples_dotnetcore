using Application.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Business.Models
{
    public class RepositoryQuery<TSource> where TSource : BaseEntity
    {
        private List<Expression<Func<TSource, bool>>> Expressions { get; set; }

        public RepositoryQuery()
        {
            Expressions = new List<Expression<Func<TSource, bool>>>();
        }

        public RepositoryQuery(Expression<Func<TSource, bool>> expression) : this()
        {
            Where(expression);
        }

        public RepositoryQuery<TSource> Where(Expression<Func<TSource, bool>> expression)
        {
            Expressions.Add(expression);

            return this;
        }

        public IQueryable<TSource> ApplyTo(IQueryable<TSource> queryable)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            foreach (var expression in Expressions)
            {
                queryable = queryable.Where(expression);
            }

            return queryable;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Expressions);
        }
    }
}
