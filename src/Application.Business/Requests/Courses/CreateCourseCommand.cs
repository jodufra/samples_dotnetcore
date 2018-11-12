using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Courses
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Course> repository;

        public CreateCourseCommandHandler(IRepository<Course> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateCourseCommand, Course>(request);

            await repository.AddAsync(entity, true, cancellationToken);

            return entity.Id;
        }
    }
}
