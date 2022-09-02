using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Lingvo.Application.Common;
using Lingvo.Application.Common.Handlers;

namespace Lingvo.API.Middlewares
{
    public class ValidationErrorResultFilter: IAsyncResultFilter
    {
        private readonly ValidationErrorHandler _errorHandler;

        public ValidationErrorResultFilter(INotificationHandler<ValidationError> errorHandler)
        {
            _errorHandler = (ValidationErrorHandler)errorHandler;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_errorHandler.HasErrors)
            {
                var errors = _errorHandler.GetErrors();

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.HttpContext.Response.WriteAsJsonAsync(errors)
                    .ConfigureAwait(false);

                return;
            }

            await next().ConfigureAwait(false);
        }
    }
}
