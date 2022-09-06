using CleanArchitectureAPi.Application.Services.Authentication;

namespace CleanArchitectureAPi.Application.Services.Interface;

public interface IAuthenticationServices
{   
    AuthenticationResult Register(string FirstName,string LastName,string Password,string Email);

    AuthenticationResult Login(string Email,string Password);
}
