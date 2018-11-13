using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.UserCourses
{
    public class UserCourseDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class UserCourseDetailQuery : IRequest<UserCourseDetailModel>
    {
        public int Id { get; set; }
    }

    public class UserCourseDetailQueryValidator : AbstractValidator<UserCourseDetailModel>
    {
        public UserCourseDetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class UserCourseDetailQueryHandler : IRequestHandler<UserCourseDetailQuery, UserCourseDetailModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<UserCourse> repository;

        public UserCourseDetailQueryHandler(IReadOnlyRepository<UserCourse> repository, IMapper mapper) 
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserCourseDetailModel> Handle(UserCourseDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Course).Name, request.Id);
            }

            return mapper.Map<UserCourse, UserCourseDetailModel>(entity);
        }
    }
}
