using Application.Business.Interfaces;
using Application.Business.Models;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Users
{
    public class UsersItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UsersListModel
    {
        public List<UsersItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class UsersListQuery : IRequest<UsersListModel>
    {
        public int? PageId { get; set; }
        public int? PageSize { get; set; }
        public string Search { get; set; }
    }

    public class UsersListQueryValidator : AbstractValidator<UsersListQuery>
    {
        public UsersListQueryValidator()
        {
            RuleFor(q => q.PageId).GreaterThan(0).When(q => q.PageId.HasValue);
            RuleFor(q => q.PageSize).GreaterThan(0).When(q => q.PageSize.HasValue);
        }
    }

    public class UsersListQueryHandler : IRequestHandler<UsersListQuery, UsersListModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<User> repository;

        public UsersListQueryHandler(IReadOnlyRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UsersListModel> Handle(UsersListQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = new RepositoryRequest<User>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                repositoryRequest.Query.Where(q => q.Name.Contains(request.Search));
            }

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return new UsersListModel
            {
                Items = repositoryResult.Items.Select(mapper.Map<User, UsersItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
