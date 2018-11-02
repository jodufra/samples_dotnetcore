using Application.Business.Infrastructure;
using Application.Domain.Infrastructure;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Commands.Abstractions
{
    public abstract class CreateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Unit>
        where TCommand : CreateCommand
        where TEntity : Entity
    {
        protected IRepository<TEntity> repository;

        protected CreateCommandHandler(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TCommand, TEntity>(request);

            await repository.AddAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
