using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
// using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Domain.Entities;
using CleanArchitectureAPi.Domain.Common.Errors;


using ErrorOr;
using MediatR;
using CleanArchitectureAPi.Application.Authentication.Common;

namespace CleanArchitectureAPi.Application.Authentication.Queries.Login;


public class Logincommandhandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IUserRepository _userRepository;

    public Logincommandhandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
         if (_userRepository.GetByEmailandPassword(email: query.Email, password: query.Password) is not Users user)
        {
            return Errors.Authentication.InvalidCredentials; 
        }

        if (user.Password != query.Password) throw new Exception("Password in in correct");

        var token = _jwtTokenGenerator.GenerateToken(user.ID, user.FirstName, user.LastName);

        return new AuthenticationResult(
            user,
            token
        );
    }
}