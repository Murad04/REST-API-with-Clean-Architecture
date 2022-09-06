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

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result=_authenticationServices.Register(request.FirstName,request.LastName,request.Password,request.Email);

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