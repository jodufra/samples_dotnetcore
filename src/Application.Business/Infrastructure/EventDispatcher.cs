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

        public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEventAsync(domainEvent);

            if (domainEvent is INotification notification)
            {
                await DispatchNotificationAsync(notification, cancellationToken);
            }
        }

        private Task DispatchNotificationAsync(INotification notification, CancellationToken cancellationToken = default)
        {
            return mediator.Publish(notification, cancellationToken);
        }

        private Task DispatchDomainEventAsync(IDomainEvent domainEvent)
        {
            logger.LogInformation("Domain Event: {@DomainEvent}", domainEvent);

            return Task.CompletedTask;
        }
    }
}
