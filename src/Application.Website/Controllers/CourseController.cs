using Application.Business.Requests.Courses;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseController : CrudController<
        CreateCourseCommand,
        UpdateCourseCommand,
        DeleteCourseCommand,
        CourseDetailQuery,
        CoursesListQuery,
        CourseDetailModel,
        CoursesListModel,
        CoursesListItemModel>
    {
        public CourseController(IMediator mediator) : base(mediator)
        {
        }
    }
}
