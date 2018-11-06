using Application.Business.Requests.UserCourses;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserCourseController : CrudController<
        CreateUserCourseCommand,
        UpdateUserCourseCommand,
        DeleteUserCourseCommand,
        UserCourseDetailQuery,
        UserCoursesListQuery,
        UserCourseDetailModel,
        UserCoursesListModel,
        UserCoursesListItemModel>
    {
        public UserCourseController(IMediator mediator) : base(mediator)
        {
        }
    }
}
