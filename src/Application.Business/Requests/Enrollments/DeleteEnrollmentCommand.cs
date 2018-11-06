using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Enrollments
{
    public class DeleteEnrollmentCommand : DeleteCommand
    {
    }

    public class DeleteEnrollmentCommandValidator : DeleteCommandValidator<DeleteEnrollmentCommand>
    {
    }

    public class DeleteEnrollmentCommandHandler : DeleteCommandHandler<DeleteEnrollmentCommand, Enrollment>
    {
        public DeleteEnrollmentCommandHandler(IRepository<Enrollment> repository) : base(repository)
        {
        }
    }
}
