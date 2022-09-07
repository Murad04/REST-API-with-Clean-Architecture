using CleanArchitectureAPi.Application.Common.Errors;
using CleanArchitectureAPi.Application.Common.Errors.Interface;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPi.Api.Controllers;

public class ErrosController:ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception=HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        // Exception handler for exceptions.
        var(statusCode,message)=exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode,serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError,"An unexpected error occured"),            
        };

        //Returns the exception useg in global error handling
        //return Problem(title:exception?.Message);
        
        //Returns DuplicateEmailException
        return Problem(statusCode:statusCode,title:message);
    }
}