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

namespace Application.Business.Services.Enrollments
{
    public class EnrollmentsItemModel
    {
        public int Id { get; set; }
    }

    public class EnrollmentsListModel
    {
        public List<EnrollmentsItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class EnrollmentsListQuery : IRequest<EnrollmentsListModel>
    {
        public int? PageId { get; set; }
        public int? PageSize { get; set; }
    }

    public class EnrollmentsListQueryValidator : AbstractValidator<EnrollmentsListQuery>
    {
        public EnrollmentsListQueryValidator()
        {
            RuleFor(q => q.PageId).GreaterThan(0).When(q => q.PageId.HasValue);
            RuleFor(q => q.PageSize).GreaterThan(0).When(q => q.PageSize.HasValue);
        }
    }

    public class EnrollmentsListQueryHandler : IRequestHandler<EnrollmentsListQuery, EnrollmentsListModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Enrollment> repository;

        public EnrollmentsListQueryHandler(IReadOnlyRepository<Enrollment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<EnrollmentsListModel> Handle(EnrollmentsListQuery request, CancellationToken cancellationToken)
        {
            var repositoryRequest = new RepositoryRequest<Enrollment>
            {
                PageId = request.PageId,
                PageSize = request.PageSize
            };

            var repositoryResult = await repository.FindAsync(repositoryRequest, cancellationToken);

            return new EnrollmentsListModel
            {
                Items = repositoryResult.Items.Select(mapper.Map<Enrollment, EnrollmentsItemModel>).ToList(),
                ItemsCount = repositoryResult.ItemsCount,
                TotalCount = repositoryResult.TotalCount
            };
        }
    }
}
