using Application.Business.Requests.Abstractions;
using Application.Business.Infrastructure;
using Application.Domain.Entities;

namespace Application.Business.Requests.Users
{
    public class DeleteUserCommandHandler : DeleteCommandHandler<DeleteUserCommand, User>
    {
        public DeleteUserCommandHandler(IRepository<User> repository) : base(repository)
        {
        }
    }
}
