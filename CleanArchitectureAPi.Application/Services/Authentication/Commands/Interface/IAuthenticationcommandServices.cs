using CleanArchitectureAPi.Application.Services.Authentication;

namespace CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;

public interface IAuthenticationcommandServices
{   
    AuthenticationResult Register(string FirstName,string LastName,string Password,string Email);
}
