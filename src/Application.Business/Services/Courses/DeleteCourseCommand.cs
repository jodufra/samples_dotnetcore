using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Courses
{
    public class DeleteCourseCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IRepository<Course> repository;

        public DeleteCourseCommandHandler(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Course).Name, request.Id);
            }

            await repository.RemoveAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
