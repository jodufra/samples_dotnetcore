using Application.Business.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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

                result = CreateExceptionResult(context.Exception, isDevelopment);
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(result);
        }

        private static IHostingEnvironment GetEnvironment(HttpContext httpContext)
        {
            return httpContext?.RequestServices.GetService<IHostingEnvironment>();
        }

        private static object CreateExceptionResult(Exception exception, bool isDevelopment)
        {
            if (exception == null)
            {
                return null;
            }

            var result = new
            {
                error = FormatMessage(exception.Message),
                stackTrace = isDevelopment ? FormatStackTrace(exception.StackTrace) : new string[] { },
                innerException = isDevelopment ? CreateExceptionResult(exception.InnerException, isDevelopment) : null
            };

            return result;
        }

        private static string[] FormatMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new string[] { };
            }

            return message.Split(Environment.NewLine).Select(q => q.Trim()).ToArray();
        }

        private static string[] FormatStackTrace(string stackTrace)
        {
            if (string.IsNullOrEmpty(stackTrace))
            {
                return new string[] { };
            }

            return stackTrace.Split(Environment.NewLine).Select(q => q.Trim()).ToArray();
        }
    }
}
