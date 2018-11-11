using Application.Domain.Entities;
using Application.Domain.SeedWork;
using MediatR;

namespace Application.Business.Notifications.Events
{
    public class OnUserCreatedEvent : INotification, IDomainEvent
    {
        public OnUserCreatedEvent(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
