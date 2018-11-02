using Application.Business.Commands.Abstractions;
using Application.Business.Infrastructure;
using Application.Domain.Entities;

namespace Application.Business.Commands.Users
{
    public class UpdateUserCommandHandler : UpdateCommandHandler<UpdateUserCommand, User>
    {
        public UpdateUserCommandHandler(IRepository<User> repository) : base(repository)
        {
        }
    }
}
