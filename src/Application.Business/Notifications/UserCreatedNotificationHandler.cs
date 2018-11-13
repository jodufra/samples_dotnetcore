using Application.Business.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Notifications
{
    public class UserCreatedNotificationHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<UserCreatedEvent> logger;

        public UserCreatedNotificationHandler(ILogger<UserCreatedEvent> logger)
        {
            this.logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            // ToDo: Replace log with a welcome email
            logger.LogInformation("Notification: {@Notification}", notification);

            return Task.CompletedTask;
        }
    }
}
