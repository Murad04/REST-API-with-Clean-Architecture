using CleanArchitectureAPi.Application.Authentication.Queries.Login;
using FluentValidation;

namespace CleanArchitectureAPi.Application.Authentication.Commands.Queries.Login;

public class LoginQueryValidator:AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x=>x.Email).NotEmpty();
        RuleFor(x=>x.Password).NotEmpty();
    }
}