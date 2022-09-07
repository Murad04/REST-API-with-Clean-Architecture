using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitectureAPi.Api.Filters;

public class ErrorHandling_FilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var errorResult = new { error = "An error occured while processing yout request." };
        context.Result = new ObjectResult(errorResult)
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }
}