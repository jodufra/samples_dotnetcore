using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Courses
{
    public class CreateCourseCommand : CreateCommand
    {
        public string Name { get; set; }
    }

    public class CreateCourseCommandValidator : CreateCommandValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateCourseCommandHandler : CreateCommandHandler<CreateCourseCommand, Course>
    {
        public CreateCourseCommandHandler(IRepository<Course> repository) : base(repository)
        {
        }
    }
}
