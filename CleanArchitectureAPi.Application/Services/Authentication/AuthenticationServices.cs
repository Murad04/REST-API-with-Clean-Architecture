using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Application.Services.Interface;
using CleanArchitectureAPi.Domain.Entities;

namespace CleanArchitectureAPi.Application.Services.Authentication;

public class AuthenticationServices : IAuthenticationServices
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IUserRepository _userRepository;

    public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Password, string Email)
    {
        if (_userRepository.GetByNameandSurname(firstName: FirstName, lastName: LastName) is not null)
        {
            if (_userRepository.GetUserByEmail(email: Email) is not null)
            {
                throw new Exception("User with given Name , Surname and Email already exists ");
            }
        }

        var user = new Users
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(userID: user.ID, firstname: FirstName, lastname: LastName);

        return new AuthenticationResult(user.ID,
                                        FirstName,
                                        LastName,
                                        Email,
                                        token);
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