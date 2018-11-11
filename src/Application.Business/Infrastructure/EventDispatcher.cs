using Application.Business.Interfaces;
using Application.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Infrastructure
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly ILogger<IDomainEvent> logger;
        private readonly IMediator mediator;

        public EventDispatcher(IMediator mediator, ILogger<IDomainEvent> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public void Dispatch(IDomainEvent domainEvent)
        {
            DispatchAsync(domainEvent).GetAwaiter().GetResult();
        }

        public Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            if (domainEvent is INotification notification)
            {
                return DispatchNotificationAsync(notification, cancellationToken);
            }

            return DispatchEventAsync(domainEvent);
        }

        private Task DispatchNotificationAsync(INotification notification, CancellationToken cancellationToken = default)
        {
            return mediator.Publish(notification, cancellationToken);
        }

        private Task DispatchEventAsync(IDomainEvent domainEvent)
        {
            logger.LogInformation("Domain Event: {@DomainEvent}", domainEvent);

            return Task.CompletedTask;
        }
    }
}
