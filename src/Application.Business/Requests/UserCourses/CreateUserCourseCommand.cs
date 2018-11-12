using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.UserCourses
{
    public class CreateUserCourseCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateUserCourseCommandValidator : AbstractValidator<CreateUserCourseCommand>
    {
        public CreateUserCourseCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateUserCourseCommandHandler : IRequestHandler<CreateUserCourseCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IRepository<UserCourse> repository;

        public CreateUserCourseCommandHandler(IRepository<UserCourse> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateUserCourseCommand, UserCourse>(request);

            await repository.AddAsync(entity, true, cancellationToken);

            return entity.Id;
        }
    }
}
