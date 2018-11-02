using Application.Domain.Infrastructure;
using System;

namespace Application.Business.Infrastructure
{
    public class RepositoryRequest<T> where T : Entity
    {
        private int? pageId;
        public int? PageId
        {
            get => pageId;
            set
            {
                if (value.HasValue && value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(PageSize));
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
