using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Users
{
    public class CreateUserCommandHandler : CreateCommandHandler<CreateUserCommand, User>
    {
        public CreateUserCommandHandler(IRepository<User> repository) : base(repository)
        {
        }
    }
}
