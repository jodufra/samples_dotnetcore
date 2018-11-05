using Application.Business.Exceptions;
using Application.Business.Infrastructure;
using Application.Business.Interfaces;
using Application.Domain.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Abstractions
{
    public abstract class DeleteCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Unit>
        where TCommand : DeleteCommand
        where TEntity : BaseEntity
    {
        protected IRepository<TEntity> repository;

        protected DeleteCommandHandler(IRepository<TEntity> repository)
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
