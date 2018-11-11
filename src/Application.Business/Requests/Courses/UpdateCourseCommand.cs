using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Courses
{
    public class UpdateCourseCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Course> repository;

        public UpdateCourseCommandHandler(IRepository<Course> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Course).Name, request.Id);
            }

            entity = mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
