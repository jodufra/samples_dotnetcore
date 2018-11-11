using Application.Business.Requests.Enrollments;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.Website.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EnrollmentController : MediatorController
    {
        public EnrollmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<EnrollmentsListModel>> Find([FromQuery] EnrollmentsListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new EnrollmentDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateEnrollmentCommand command)
        {
            return Created(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateEnrollmentCommand command)
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
            await Mediator.Send(new DeleteEnrollmentCommand { Id = id });

            return Ok();
        }
    }
}
