using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Services.Interface;

namespace CleanArchitectureAPi.Application.Services.Authentication;

public class AuthenticationServices : IAuthenticationServices
{
    private IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Password, string Email)
    {
        Guid userId=Guid.NewGuid();
        var token=_jwtTokenGenerator.GenerateToken(userID:userId,firstname: FirstName, lastname: LastName);

        return new AuthenticationResult(userId,
                                        FirstName,
                                        LastName,
                                        Email,
                                        token);
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(),
                                        "FirstName",
                                        "LastName",
                                        Email,
                                        "token");
    }
}