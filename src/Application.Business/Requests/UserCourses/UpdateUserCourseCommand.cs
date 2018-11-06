using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.UserCourses
{
    public class UpdateUserCourseCommand : UpdateCommand
    {
        public string Name { get; set; }
    }

    public class UpdateUserCourseCommandValidator : UpdateCommandValidator<UpdateUserCourseCommand>
    {
        public UpdateUserCourseCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateUserCourseCommandHandler : UpdateCommandHandler<UpdateUserCourseCommand, UserCourse>
    {
        public UpdateUserCourseCommandHandler(IRepository<UserCourse> repository) : base(repository)
        {
        }
    }
}
