using Application.Business.Requests.Users;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : MediatorController<
        CreateUserCommand,
        UpdateUserCommand,
        DeleteUserCommand,
        UserDetailQuery,
        UsersListQuery,
        UserDetailModel,
        UsersListModel,
        UsersListItemModel>
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
    }
}
