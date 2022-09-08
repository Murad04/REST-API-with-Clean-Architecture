using CleanArchitectureAPi.Api.Filters;
using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;
using CleanArchitectureAPi.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPi.Api.Controllers;

[Route("auth")]
//[ErrorHandling_Filter]
public class AuthenticationController : ApiController
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
        ErrorOr<AuthenticationResult> result = _authenticationCommandServices.Register(request.FirstName,
                                                                                     request.LastName,
                                                                                     request.Password,
                                                                                     request.Email);


        // Authenticates a map auth result.
        return result.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // Login to the Authentication service.
        ErrorOr<AuthenticationResult> result = _authenticationQueryServices.Login(request.Email, request.Password);

        return result.Match(
            result => Ok(MapLoginResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapLoginResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token);
    }
}