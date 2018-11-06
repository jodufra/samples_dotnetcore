using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Courses
{
    public class DeleteCourseCommand : DeleteCommand
    {
    }

    public class DeleteCourseCommandValidator : DeleteCommandValidator<DeleteCourseCommand>
    {
    }

    public class DeleteCourseCommandHandler : DeleteCommandHandler<DeleteCourseCommand, Course>
    {
        public DeleteCourseCommandHandler(IRepository<Course> repository) : base(repository)
        {
        }
    }
}
