using CleanArchitectureAPi.Application.Common.Errors;
using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;
using CleanArchitectureAPi.Domain.Entities;

namespace CleanArchitectureAPi.Application.Services.Authentication.Queries.Login;

public class AuthenticationQueryServices : IAuthenticationQueryServices
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IUserRepository _userRepository;

    public AuthenticationQueryServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public AuthenticationResult Login(string Email, string Password)
    {
        if (_userRepository.GetByEmailandPassword(email: Email, password: Password) is not Users user)
        {
            throw new Exception("User does not exists ");
        }

        if (user.Password != Password) throw new Exception("Password in in correct");

        var token = _jwtTokenGenerator.GenerateToken(user.ID, user.FirstName, user.LastName);

        return new AuthenticationResult(
            user.ID,
            user.FirstName,
            user.LastName,
            user.Email,
            token
        );
    }
}