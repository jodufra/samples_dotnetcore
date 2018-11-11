using Application.Business.Interfaces;
using Application.Domain.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persistence.Infrastructure
{
    public class DesignTimeEventDispatcher : IEventDispatcher
    {
        public void Dispatch(IDomainEvent domainEvent)
        {
        }

        public Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
