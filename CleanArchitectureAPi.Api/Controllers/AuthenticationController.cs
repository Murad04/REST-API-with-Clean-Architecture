using CleanArchitectureAPi.Application.Services.Interface;
using CleanArchitectureAPi.Contracts.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPi.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController :ControllerBase
{
    private IAuthenticationServices _authenticationServices;

    public AuthenticationController(IAuthenticationServices authenticationServices)
    {
        _authenticationServices = authenticationServices;
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
        var result=_authenticationServices.Register(request.FirstName,request.LastName,request.Password,request.Email);
        /** 
        *?  Check the inputted data
        */
        var response=new AuthenticationResponse(result.Id,result.FirstName,result.LastName,result.Email,result.Token);

        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result=_authenticationServices.Login(request.Email,request.Password);

        var response=new AuthenticationResponse(result.Id,result.FirstName,result.LastName,result.Email,result.Token);

        return Ok(response);
    }
}