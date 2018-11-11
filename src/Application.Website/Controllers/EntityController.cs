using Application.Business.Requests.Entities;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EntityController : MediatorController
    {
        public EntityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<EntitiesListModel>> Find([FromQuery] EntitiesListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntityDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new EntityDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateEntityCommand command)
        {
            return Created(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateEntityCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEntityCommand { Id = id });

            return Ok();
        }
    }
}
