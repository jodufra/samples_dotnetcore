using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.UserCourses
{
    public class CreateUserCourseCommand : CreateCommand
    {
        public string Name { get; set; }
    }

    public class CreateUserCourseCommandValidator : CreateCommandValidator<CreateUserCourseCommand>
    {
        public CreateUserCourseCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateUserCourseCommandHandler : CreateCommandHandler<CreateUserCourseCommand, UserCourse>
    {
        public CreateUserCourseCommandHandler(IRepository<UserCourse> repository) : base(repository)
        {
        }
    }
}
