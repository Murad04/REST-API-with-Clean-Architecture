using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitectureAPi.Api.Filters;

public class ErrorHandling_FilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        // Get the exception from the context. 
        var exception = context.Exception;
        // Creates a new ProblemDetails object and initializes it
        var problemDetails=new ProblemDetails
        {
            Title="An error occured while processing yout request.",
            Status=(int)HttpStatusCode.InternalServerError,
            Type="https://tools.ietf.org/html/rfc7231#section-6.6.1",
        };
        // Creates a new ObjectResult object with the problem details.
        context.Result = new ObjectResult(problemDetails);
        // Invoked when an exception has been handled.
        context.ExceptionHandled = true;
    }
}