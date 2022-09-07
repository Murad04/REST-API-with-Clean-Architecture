using CleanArchitectureAPi.Api.Filters;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;
using CleanArchitectureAPi.Contracts.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPi.Api.Controllers;

[ApiController]
[Route("auth")]
//[ErrorHandling_Filter]
public class AuthenticationController : ControllerBase
{
    private IAuthenticationcommandServices _authenticationCommandServices;

    private IAuthenticationQueryServices _authenticationQueryServices;


    public AuthenticationController(IAuthenticationcommandServices authenticationCommandServices, IAuthenticationQueryServices authenticationQueryServices)
    {
        _authenticationCommandServices = authenticationCommandServices;
        _authenticationQueryServices = authenticationQueryServices;
    }

    /**
    * Register API Endpoint
    * @param request The parameter for this Endpoint
    */
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        /**
        *? Getting the result from IAuthenticationServices in order to check registering is completed.
        */
        var result = _authenticationCommandServices.Register(request.FirstName, request.LastName, request.Password, request.Email);
        /** 
        *?  Check the inputted data
        */
        var response = new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // Login to the Authentication service.
        var result = _authenticationQueryServices.Login(request.Email, request.Password);

        // Creates a AuthenticationResponse with the given ID LastName Email and Token.
        var response = new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token);

        // Return the response status.
        return Ok(response);
    }
}