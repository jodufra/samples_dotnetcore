using Application.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Business.Models
{
    public class RepositoryResult<T> where T : BaseEntity
    {
        public IEnumerable<T> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }

        public RepositoryResult()
        {
        }

        public RepositoryResult(IEnumerable<T> items)
        {
            Items = items;
            ItemsCount = items.Count();
            TotalCount = ItemsCount;
        }

        public RepositoryResult(IEnumerable<T> items, int totalCount) : this(items)
        {
            TotalCount = totalCount;
        }
    }
}
