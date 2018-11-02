using Application.Business.Infrastructure;
using Application.Domain.Infrastructure;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Queries.Abstractions
{
    public abstract class ListQueryHandler<TQuery, TModel, TItemModel, TEntity> : IRequestHandler<TQuery, TModel>
        where TQuery : ListQuery<TModel, TItemModel>
        where TModel : ListModel<TItemModel>, new()
        where TItemModel : ListItemModel
        where TEntity : Entity
    {
        protected IReadOnlyRepository<TEntity> repository;

        protected ListQueryHandler(IReadOnlyRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<TModel> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = BuildRepositoryRequest(request);

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return BuildResponseModel(repositoryResult);
        }

        public virtual RepositoryRequest<TEntity> BuildRepositoryRequest(TQuery request)
        {
            var repositoryRequest = new RepositoryRequest<TEntity>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            return repositoryRequest;
        }

        public virtual TModel BuildResponseModel(RepositoryResult<TEntity> repositoryResult)
        {
            return new TModel
            {
                Items = repositoryResult.Items.Select(Mapper.Map<TEntity, TItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
