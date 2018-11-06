using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Enrollments
{
    public class CreateEnrollmentCommand : CreateCommand
    {
        public string Name { get; set; }
    }

    public class CreateEnrollmentCommandValidator : CreateCommandValidator<CreateEnrollmentCommand>
    {
        public CreateEnrollmentCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateEnrollmentCommandHandler : CreateCommandHandler<CreateEnrollmentCommand, Enrollment>
    {
        public CreateEnrollmentCommandHandler(IRepository<Enrollment> repository) : base(repository)
        {
        }
    }
}
