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

namespace Application.Business.Requests.UserCourses
{
    public class UserCoursesItemModel
    {
        public int Id { get; set; }
    }

    public class UserCoursesListModel
    {
        public List<UserCoursesItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class UserCoursesListQuery : IRequest<UserCoursesListModel>
    {
        public int? PageId { get; set; }
        public int? PageSize { get; set; }
    }

    public class UserCoursesListQueryValidator : AbstractValidator<UserCoursesListQuery>
    {
        public UserCoursesListQueryValidator()
        {
            RuleFor(q => q.PageId).GreaterThan(0).When(q => q.PageId.HasValue);
            RuleFor(q => q.PageSize).GreaterThan(0).When(q => q.PageSize.HasValue);
        }
    }

    public class UserCoursesListQueryHandler : IRequestHandler<UserCoursesListQuery, UserCoursesListModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<UserCourse> repository;

        public UserCoursesListQueryHandler(IReadOnlyRepository<UserCourse> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserCoursesListModel> Handle(UserCoursesListQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = new RepositoryRequest<UserCourse>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return new UserCoursesListModel
            {
                Items = repositoryResult.Items.Select(mapper.Map<UserCourse, UserCoursesItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
