using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Entities
{
    public class DeleteEntityCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteEntityCommandValidator : AbstractValidator<DeleteEntityCommand>
    {
        public DeleteEntityCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DeleteEntityCommandHandler : IRequestHandler<DeleteEntityCommand>
    {
        private readonly IRepository<Entity> repository;

        public DeleteEntityCommandHandler(IRepository<Entity> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Entity).Name, request.Id);
            }

            await repository.RemoveAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
