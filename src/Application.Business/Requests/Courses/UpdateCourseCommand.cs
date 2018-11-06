using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Courses
{
    public class UpdateCourseCommand : UpdateCommand
    {
        public string Name { get; set; }
    }

    public class UpdateCourseCommandValidator : UpdateCommandValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateCourseCommandHandler : UpdateCommandHandler<UpdateCourseCommand, Course>
    {
        public UpdateCourseCommandHandler(IRepository<Course> repository) : base(repository)
        {
        }
    }
}
