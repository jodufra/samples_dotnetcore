using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Website.Controllers.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class MediatorController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        protected MediatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected CreatedResult Created(int id)
        {
            return Created(new Uri(id.ToString(), UriKind.Relative), id);
        }
    }
}
