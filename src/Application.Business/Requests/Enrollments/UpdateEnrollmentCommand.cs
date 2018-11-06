using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Enrollments
{
    public class UpdateEnrollmentCommand : UpdateCommand
    {
        public string Name { get; set; }
    }

    public class UpdateEnrollmentCommandValidator : UpdateCommandValidator<UpdateEnrollmentCommand>
    {
        public UpdateEnrollmentCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateEnrollmentCommandHandler : UpdateCommandHandler<UpdateEnrollmentCommand, Enrollment>
    {
        public UpdateEnrollmentCommandHandler(IRepository<Enrollment> repository) : base(repository)
        {
        }
    }
}
