using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Enrollments
{
    public class DeleteEnrollmentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteEnrollmentCommandValidator : AbstractValidator<DeleteEnrollmentCommand>
    {
        public DeleteEnrollmentCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand>
    {
        private readonly IRepository<Enrollment> repository;

        public DeleteEnrollmentCommandHandler(IRepository<Enrollment> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Enrollment).Name, request.Id);
            }

            await repository.RemoveAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
