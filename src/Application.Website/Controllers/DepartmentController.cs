using Application.Business.Requests.Departments;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DepartmentController : MediatorController<
        CreateDepartmentCommand,
        UpdateDepartmentCommand,
        DeleteDepartmentCommand,
        DepartmentDetailQuery,
        DepartmentsListQuery,
        DepartmentDetailModel,
        DepartmentsListModel,
        DepartmentsListItemModel>
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }
    }
}
