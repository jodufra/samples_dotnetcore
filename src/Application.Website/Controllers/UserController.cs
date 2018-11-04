using Application.Business.Requests.Users;
using Application.Website.Controllers.Abstractions;
using MediatR;

namespace Application.Website.Controllers
{
    public class UserController : CrudController<
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
