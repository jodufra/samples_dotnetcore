using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.UserCourses
{
    public class DeleteUserCourseCommand : DeleteCommand
    {
    }

    public class DeleteUserCourseCommandValidator : DeleteCommandValidator<DeleteUserCourseCommand>
    {
    }

    public class DeleteUserCourseCommandHandler : DeleteCommandHandler<DeleteUserCourseCommand, UserCourse>
    {
        public DeleteUserCourseCommandHandler(IRepository<UserCourse> repository) : base(repository)
        {
        }
    }
}
