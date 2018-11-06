using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.UserCourses
{
    public class UserCourseDetailModel : DetailModel
    {
        public string Name { get; set; }
    }

    public class UserCourseDetailQuery : DetailQuery<UserCourseDetailModel>
    {
    }

    public class UserCourseDetailQueryValidator : DetailQueryValidator<UserCourseDetailQuery, UserCourseDetailModel>
    {
    }

    public class UserCourseDetailQueryHandler : DetailQueryHandler<UserCourseDetailQuery, UserCourseDetailModel, UserCourse>
    {
        public UserCourseDetailQueryHandler(IReadOnlyRepository<UserCourse> repository) : base(repository)
        {
        }
    }
}
