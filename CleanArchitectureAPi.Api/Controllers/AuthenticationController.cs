using CleanArchitectureAPi.Api.Filters;
//using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;
using CleanArchitectureAPi.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureAPi.Application.Authentication.Commands.Register;
using CleanArchitectureAPi.Application.Authentication.Common;
using CleanArchitectureAPi.Application.Authentication.Queries.Login;

namespace CleanArchitectureAPi.Api.Controllers;

[Route("auth")]
//[ErrorHandling_Filter]
public class AuthenticationController : ApiController
{
    private IMediator _mediatr;

    public AuthenticationController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    //private IAuthenticationcommandServices _authenticationCommandServices;

    //private IAuthenticationQueryServices _authenticationQueryServices;


    /*public AuthenticationController(IAuthenticationcommandServices authenticationCommandServices, IAuthenticationQueryServices authenticationQueryServices)
    {
        _authenticationCommandServices = authenticationCommandServices;
        _authenticationQueryServices = authenticationQueryServices;
    }*/



    /**
    * Register API Endpoint
    * @param request The parameter for this Endpoint
    */
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new Registercommand(request.FirstName,
                                                                                     request.LastName,
                                                                                     request.Email,
                                                                                     request.Password);

        ErrorOr<AuthenticationResult> result = await _mediatr.Send(command);

        /**
        *? Getting the result from IAuthenticationServices in order to check registering is completed.
        */
        //ErrorOr<AuthenticationResult> result = _authenticationCommandServices.Register(request.FirstName,
        //                                                                             request.LastName,
        //                                                                             request.Password,
        //                                                                            request.Email);

        // Authenticates a map auth result.
        return result.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(result.User.ID, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // Login to the Authentication service.
        //ErrorOr<AuthenticationResult> result = _authenticationQueryServices.Login(request.Email, request.Password);
 
        var query=new LoginQuery(request.Email,request.Password);
        var result=await _mediatr.Send(query);

        return result.Match(
            result => Ok(MapLoginResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapLoginResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(result.User.ID, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
    }
}