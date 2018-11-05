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
    public abstract class DetailQueryHandler<TQuery, TModel, TEntity> : IRequestHandler<TQuery, TModel>
        where TQuery : DetailQuery<TModel>
        where TModel : DetailModel
        where TEntity : BaseEntity
    {
        protected IReadOnlyRepository<TEntity> repository;

        protected DetailQueryHandler(IReadOnlyRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<TModel> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, request.Id);
            }

            return Mapper.Map<TEntity, TModel>(entity);
        }
    }
}
