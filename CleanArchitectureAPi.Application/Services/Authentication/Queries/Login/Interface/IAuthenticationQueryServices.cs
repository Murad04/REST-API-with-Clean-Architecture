using CleanArchitectureAPi.Application.Services.Authentication;
using ErrorOr;

namespace CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;

public interface IAuthenticationQueryServices
{   
    ErrorOr<AuthenticationResult> Login(string Email,string Password);
}
