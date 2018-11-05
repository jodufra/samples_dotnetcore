using System.Threading;
using System.Threading.Tasks;
using Application.Business.Interfaces;
using Application.Domain.Infrastructure;
using AutoMapper;
using MediatR;

namespace Application.Business.Requests.Abstractions
{
    public abstract class CreateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Unit>
        where TCommand : CreateCommand
        where TEntity : BaseEntity
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
