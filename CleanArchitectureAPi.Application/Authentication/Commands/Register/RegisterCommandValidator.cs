using FluentValidation;

namespace CleanArchitectureAPi.Application.Authentication.Commands.Register;

public class RegisterCommandValidator:AbstractValidator<Registercommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x=>x.LastName).NotEmpty();
        RuleFor(x=>x.FirstName).NotEmpty();
        RuleFor(x=>x.Email).NotEmpty();
        RuleFor(x=>x.Password).NotEmpty();
    }
}