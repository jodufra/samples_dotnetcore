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

namespace Application.Business.Requests.Courses
{
    public class CoursesItemModel
    {
        public int Id { get; set; }
    }

    public class CoursesListModel
    {
        public List<CoursesItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class CoursesListQuery : IRequest<CoursesListModel>
    {
        public int? PageId { get; set; }
        public int? PageSize { get; set; }
    }

    public class CoursesListQueryValidator : AbstractValidator<CoursesListQuery>
    {
        public CoursesListQueryValidator()
        {
            RuleFor(q => q.PageId).GreaterThan(0).When(q => q.PageId.HasValue);
            RuleFor(q => q.PageSize).GreaterThan(0).When(q => q.PageSize.HasValue);
        }
    }

    public class CoursesListQueryHandler : IRequestHandler<CoursesListQuery, CoursesListModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Course> repository;

        public CoursesListQueryHandler(IReadOnlyRepository<Course> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CoursesListModel> Handle(CoursesListQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = new RepositoryRequest<Course>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return new CoursesListModel
            {
                Items = repositoryResult.Items.Select(mapper.Map<Course, CoursesItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
