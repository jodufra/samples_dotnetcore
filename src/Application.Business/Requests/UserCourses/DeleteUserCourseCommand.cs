using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Business.Requests.UserCourses
{
    public class DeleteUserCourseCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteUserCourseCommandValidator : AbstractValidator<DeleteUserCourseCommand>
    {
        public DeleteUserCourseCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DeleteUserCourseCommandHandler : IRequestHandler<DeleteUserCourseCommand>
    {
        private readonly IRepository<UserCourse> repository;

        public DeleteUserCourseCommandHandler(IRepository<UserCourse> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(UserCourse).Name, request.Id);
            }

            await repository.RemoveAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
