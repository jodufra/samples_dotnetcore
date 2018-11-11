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

namespace Application.Business.Requests.Departments
{
    public class DepartmentsItemModel
    {
        public int Id { get; set; }
    }

    public class DepartmentsListModel
    {
        public List<DepartmentsItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class DepartmentsListQuery : IRequest<DepartmentsListModel>
    {
        public int? PageId { get; set; }
        public int? PageSize { get; set; }
    }

    public class DepartmentsListQueryValidator : AbstractValidator<DepartmentsListQuery>
    {
        public DepartmentsListQueryValidator()
        {
            RuleFor(q => q.PageId).GreaterThan(0).When(q => q.PageId.HasValue);
            RuleFor(q => q.PageSize).GreaterThan(0).When(q => q.PageSize.HasValue);
        }
    }

    public class DepartmentsListQueryHandler : IRequestHandler<DepartmentsListQuery, DepartmentsListModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Department> repository;

        public DepartmentsListQueryHandler(IReadOnlyRepository<Department> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DepartmentsListModel> Handle(DepartmentsListQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = new RepositoryRequest<Department>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return new DepartmentsListModel
            {
                Items = repositoryResult.Items.Select(mapper.Map<Department, DepartmentsItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
