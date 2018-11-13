using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Users
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IRepository<User> repository;

        public DeleteUserCommandHandler(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(User).Name, request.Id);
            }

            await repository.RemoveAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
