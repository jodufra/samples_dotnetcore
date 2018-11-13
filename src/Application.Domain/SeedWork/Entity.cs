using System.Collections.Generic;

namespace Application.Domain.SeedWork
{
    public abstract class Entity
    {
        private int? _requestedHashCode;
        private readonly List<IDomainEvent> _domainEvents;

        protected Entity()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        public virtual int Id { get; protected set; }

        public ICollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                return;
            }

            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            if (domainEvent is null)
            {
                return;
            }

            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public bool IsTransient()
        {
            return Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
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

            var item = (Entity)obj;

            return !item.IsTransient() && !IsTransient() && item.Id == Id;
        }

        public override int GetHashCode()
        {
            if (IsTransient())
            {
                return base.GetHashCode();
            }

#pragma warning disable RECS0025 // Non-readonly field referenced in 'GetHashCode()'
            if (!_requestedHashCode.HasValue)
            {
                _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
            }
            return _requestedHashCode.Value;
#pragma warning restore RECS0025 // Non-readonly field referenced in 'GetHashCode()'
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
