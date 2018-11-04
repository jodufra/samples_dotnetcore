using Application.Business.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace Application.Website.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            object result = null;
            var statusCode = HttpStatusCode.InternalServerError;

            if (context.Exception is ValidationException validationException)
            {
                statusCode = HttpStatusCode.BadRequest;
                result = validationException.Failures;
            }
            else
            {
                if (context.Exception is NotFoundException)
                {
                    statusCode = HttpStatusCode.NotFound;
                }

                var isDevelopment = GetEnvironment(context.HttpContext)?.IsDevelopment() ?? true;

                result = new
                {
                    error = new[] { context.Exception.Message },
                    stackTrace = isDevelopment ? context.Exception.StackTrace : string.Empty
                };
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(result);
        }

        private static IHostingEnvironment GetEnvironment(HttpContext httpContext)
        {
            return httpContext?.RequestServices.GetService<IHostingEnvironment>();
        }
    }
}
