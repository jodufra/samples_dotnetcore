using Application.Business.Notifications.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Notifications.Handlers
{
    public class OnUserCreatedHandler : INotificationHandler<OnUserCreatedEvent>
    {
        private readonly ILogger<OnUserCreatedEvent> logger;

        public OnUserCreatedHandler(ILogger<OnUserCreatedEvent> logger)
        {
            this.logger = logger;
        }

        public Task Handle(OnUserCreatedEvent notification, CancellationToken cancellationToken)
        {
            // ToDo: Replace log with a welcome user email
            logger.LogInformation("Notification: {@Notification}", notification);

            return Task.CompletedTask;
        }
    }
}
