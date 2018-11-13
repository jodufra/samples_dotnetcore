using Application.Business.Services.Courses;
using Application.Website.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Application.Website.Controllers
{
    public class CourseController : MediatorController
    {
        public CourseController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<CoursesListModel>> Find([FromQuery] CoursesListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new CourseDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCourseCommand command)
        {
            return Created(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateCourseCommand command)
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
            await Mediator.Send(new DeleteCourseCommand { Id = id });

            return Ok();
        }
    }
}
