using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
//using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Domain.Entities;
using CleanArchitectureAPi.Domain.Common.Errors;


using ErrorOr;
using MediatR;
using CleanArchitectureAPi.Application.Authentication.Common;

namespace CleanArchitectureAPi.Application.Authentication.Commands.Register;


public class Registercommandhandler : IRequestHandler<Registercommand, ErrorOr<AuthenticationResult>>
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IUserRepository _userRepository;

    public Registercommandhandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(Registercommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByNameandSurname(firstName: command.FirstName, lastName: command.LastName) is not null)
        {
            if (_userRepository.GetUserByEmail(email: command.Email) is not null)
            {
                //throw new DuplicateEmailException();
                return Errors.User.DuplicateEmail;

                //This is used for global error exception
                //throw new Exception("User with given Name , Surname and Email already exists ");
            }
        }

        var user = new Users
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(userID: user.ID, firstname: command.FirstName, lastname: command.LastName);

        return new AuthenticationResult(user,
                                               token);
    }
}