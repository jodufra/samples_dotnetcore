using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Courses
{
    public class CourseDetailModel : DetailModel
    {
        public string Name { get; set; }
    }

    public class CourseDetailQuery : DetailQuery<CourseDetailModel>
    {
    }

    public class CourseDetailQueryValidator : DetailQueryValidator<CourseDetailQuery, CourseDetailModel>
    {
    }

    public class CourseDetailQueryHandler : DetailQueryHandler<CourseDetailQuery, CourseDetailModel, Course>
    {
        public CourseDetailQueryHandler(IReadOnlyRepository<Course> repository) : base(repository)
        {
        }
    }
}
