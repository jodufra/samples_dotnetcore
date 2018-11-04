using Application.Business.Requests.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Website.Controllers.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class CrudController<TCreateCommand, TUpdateCommand, TDeleteComand, TDetailQuery, TListQuery, TDetailModel, TListModel, TListItemModel>
        : BaseController
        where TCreateCommand : CreateCommand, new()
        where TUpdateCommand : UpdateCommand, new()
        where TDeleteComand : DeleteCommand, new()
        where TDetailQuery : DetailQuery<TDetailModel>, new()
        where TListQuery : ListQuery<TListModel, TListItemModel>, new()
        where TDetailModel : DetailModel
        where TListModel : ListModel<TListItemModel>
        where TListItemModel : ListItemModel
    {
        protected CrudController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<TListModel>> GetAll([FromQuery] TListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new TDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Create([FromBody]TCreateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Update(int id, [FromBody]TUpdateCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new TDeleteComand { Id = id });

            return NoContent();
        }
    }
}
