using Application.Business.Commands.Abstractions;
using Application.Business.Infrastructure;
using Application.Domain.Entities;

namespace Application.Business.Commands.Users
{
    public class RemoveUserCommandHandler : RemoveCommandHandler<RemoveUserCommand, User>
    {
        public RemoveUserCommandHandler(IRepository<User> repository) : base(repository)
        {
        }
    }
}
