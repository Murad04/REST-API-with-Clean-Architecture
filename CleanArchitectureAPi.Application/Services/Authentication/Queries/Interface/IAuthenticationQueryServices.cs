using CleanArchitectureAPi.Application.Services.Authentication;

namespace CleanArchitectureAPi.Application.Services.Authentication.Queries.Interface;

public interface IAuthenticationQueryServices
{   
    AuthenticationResult Login(string Email,string Password);
}
