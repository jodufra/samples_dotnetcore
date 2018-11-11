using Application.Domain.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IEventDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
        Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
