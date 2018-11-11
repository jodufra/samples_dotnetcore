using System;
using System.Collections.Generic;

namespace Application.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DomainEvents = new HashSet<IDomainEvent>();
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public ICollection<IDomainEvent> DomainEvents { get; }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            if (DomainEvents is null || domainEvent is null)
            {
                return;
            }

            DomainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            if (DomainEvents is null || domainEvent is null)
            {
                return;
            }

            DomainEvents.Remove(domainEvent);
        }

        public bool IsTransient()
        {
            return Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var item = (BaseEntity)obj;
            return !item.IsTransient() && !IsTransient() && item.Id == Id;
        }

        private int? _requestedHashCode;
        public override int GetHashCode()
        {
            if (IsTransient())
            {
                return base.GetHashCode();
            }

#pragma warning disable RECS0025 // Non-readonly field referenced in 'GetHashCode()'
            if (!_requestedHashCode.HasValue)
            {
                _requestedHashCode = Id.GetHashCode() ^ 31;
            }

            // XOR for random distribution. See:
            // https://blogs.msdn.microsoft.com/ericlippert/2011/02/28/guidelines-and-rules-for-gethashcode/
            return _requestedHashCode.Value;
#pragma warning restore RECS0025 // Non-readonly field referenced in 'GetHashCode()'
        }

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
    }
}
