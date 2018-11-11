using Application.Business.Interfaces;
using Application.Business.Models;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Entities
{
    public class EntitiesItemModel
    {
        public int Id { get; set; }
    }

    public class EntitiesListModel
    {
        public List<EntitiesItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class EntitiesListQuery : IRequest<EntitiesListModel>
    {
        public int? PageId { get; set; }
        public int? PageSize { get; set; }
    }

    public class EntitiesListQueryValidator : AbstractValidator<EntitiesListQuery>
    {
        public EntitiesListQueryValidator()
        {
            RuleFor(q => q.PageId).GreaterThan(0).When(q => q.PageId.HasValue);
            RuleFor(q => q.PageSize).GreaterThan(0).When(q => q.PageSize.HasValue);
        }
    }

    public class EntitiesListQueryHandler : IRequestHandler<EntitiesListQuery, EntitiesListModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Entity> repository;

        public EntitiesListQueryHandler(IReadOnlyRepository<Entity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<EntitiesListModel> Handle(EntitiesListQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = new RepositoryRequest<Entity>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return new EntitiesListModel
            {
                Items = repositoryResult.Items.Select(mapper.Map<Entity, EntitiesItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
