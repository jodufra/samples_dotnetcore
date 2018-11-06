using System;

namespace Application.Domain.Infrastructure
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
