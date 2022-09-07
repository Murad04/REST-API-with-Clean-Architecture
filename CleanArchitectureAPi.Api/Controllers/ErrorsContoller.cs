using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPi.Api.Controllers;

public class ErrosController:ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception=HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem(title:exception?.Message);
    }
}