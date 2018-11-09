using Application.Business.Requests.Entities;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EntityController : MediatorController<
        CreateEntityCommand,
        UpdateEntityCommand,
        DeleteEntityCommand,
        EntityDetailQuery,
        EntitiesListQuery,
        EntityDetailModel,
        EntitiesListModel,
        EntitiesListItemModel>
    {
        public EntityController(IMediator mediator) : base(mediator)
        {
        }
    }
}
