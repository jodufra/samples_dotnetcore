using Application.Business.Commands.Abstractions;
using Application.Business.Infrastructure;
using Application.Domain.Entities;

namespace Application.Business.Commands.Users
{
    public class CreateUserCommandHandler : CreateCommandHandler<CreateUserCommand, User>
    {
        public CreateUserCommandHandler(IRepository<User> repository) : base(repository)
        {
        }
    }
}
