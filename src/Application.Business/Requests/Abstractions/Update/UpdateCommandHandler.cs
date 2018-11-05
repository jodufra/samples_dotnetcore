using Application.Business.Exceptions;
using Application.Business.Infrastructure;
using Application.Business.Interfaces;
using Application.Domain.Infrastructure;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Abstractions
{
    public abstract class UpdateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Unit>
        where TCommand : UpdateCommand
        where TEntity : BaseEntity
    {
        protected IRepository<TEntity> repository;

        protected UpdateCommandHandler(IRepository<TEntity> repository)
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

            entity = Mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
