using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Courses
{
    public class CourseDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class CourseDetailQuery : IRequest<CourseDetailModel>
    {
        public int Id { get; set; }
    }

    public class CourseDetailQueryValidator : AbstractValidator<CourseDetailQuery>
    {
        public CourseDetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class CourseDetailQueryHandler : IRequestHandler<CourseDetailQuery, CourseDetailModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Course> repository;

        public CourseDetailQueryHandler(IReadOnlyRepository<Course> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CourseDetailModel> Handle(CourseDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Course).Name, request.Id);
            }

            return mapper.Map<Course, CourseDetailModel>(entity);
        }
    }
}
