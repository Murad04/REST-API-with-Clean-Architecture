using CleanArchitectureAPi.Application.Services.Authentication;

namespace CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;

public interface IAuthenticationQueryServices
{   
    AuthenticationResult Login(string Email,string Password);
}
