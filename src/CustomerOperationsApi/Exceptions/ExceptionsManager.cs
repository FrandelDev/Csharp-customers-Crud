using CustomerOperationsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerOperationsApi.Exceptions
{
    public class ExceptionsManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ResponseApiService.Response(StatusCodes.Status500InternalServerError,context.Exception.Message));

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }

    }
}
