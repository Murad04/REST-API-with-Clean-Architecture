using CleanArchitectureAPi.Application.Services.Authentication;
using ErrorOr;
namespace CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;

public interface IAuthenticationcommandServices
{   
    ErrorOr<AuthenticationResult> Register(string FirstName,string LastName,string Password,string Email);
}
