using Application.Common;
using Application.Domain.SeedWork;
using System;

namespace Application.Business.Models
{
    public class RepositoryRequest<T> where T : Entity
    {
        public RepositoryRequest()
        {
            PageId = 1;
            PageSize = Constants.DEFAULT_PAGE_SIZE;
            Query = new RepositoryQuery<T>();
            Order = RepositoryOrder<T>.OrderBy(q => q.Id);
        }

        private int? pageId;
        public int? PageId
        {
            get => pageId;
            set
            {
                if (value.HasValue && value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(PageId));
                }

                pageId = value;
            }
        }

        private int? pageSize;
        public int? PageSize
        {
            get => pageSize;
            set
            {
                if (value.HasValue && value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(PageSize));
                }

                pageSize = value;
            }
        }

        public RepositoryQuery<T> Query { get; set; }

        public RepositoryOrder<T> Order { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(PageId, PageSize, Query, Order);
        }
    }
}
