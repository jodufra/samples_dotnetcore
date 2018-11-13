using Application.Domain.Entities;
using Application.Domain.SeedWork;
using MediatR;

namespace Application.Business.Events
{
    public class UserCreatedEvent : INotification, IDomainEvent
    {
        public UserCreatedEvent(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
