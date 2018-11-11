using Application.Business.Requests.Departments;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DepartmentController : MediatorController
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<DepartmentsListModel>> Find([FromQuery] DepartmentsListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new DepartmentDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateDepartmentCommand command)
        {
            return Created(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateDepartmentCommand command)
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
            await Mediator.Send(new DeleteDepartmentCommand { Id = id });

            return Ok();
        }
    }
}
