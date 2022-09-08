using CleanArchitectureAPi.Application.Common.Errors;
using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Domain.Common.Errors;
using CleanArchitectureAPi.Domain.Entities;
using ErrorOr;
namespace CleanArchitectureAPi.Application.Services.Authentication.Commands;

public class AuthenticationCommandServices : IAuthenticationcommandServices
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IUserRepository _userRepository;

    public AuthenticationCommandServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Password, string Email)
    {
        if (_userRepository.GetByNameandSurname(firstName: FirstName, lastName: LastName) is not null)
        {
            if (_userRepository.GetUserByEmail(email: Email) is not null)
            {
                //throw new DuplicateEmailException();
                return Errors.User.DuplicateEmail;

                //This is used for global error exception
                //throw new Exception("User with given Name , Surname and Email already exists ");
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
}