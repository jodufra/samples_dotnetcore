using Application.Business.Exceptions;
using Application.Business.Infrastructure;
using Application.Domain.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Commands.Abstractions
{
    public abstract class RemoveCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Unit>
        where TCommand : RemoveCommand
        where TEntity : Entity
    {
        protected IRepository<TEntity> repository;

        protected RemoveCommandHandler(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, request.Id);
            }

            await repository.RemoveAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
