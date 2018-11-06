using Application.Business.Requests.Enrollments;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EnrollmentController : CrudController<
        CreateEnrollmentCommand,
        UpdateEnrollmentCommand,
        DeleteEnrollmentCommand,
        EnrollmentDetailQuery,
        EnrollmentsListQuery,
        EnrollmentDetailModel,
        EnrollmentsListModel,
        EnrollmentsListItemModel>
    {
        public EnrollmentController(IMediator mediator) : base(mediator)
        {
        }
    }
}
