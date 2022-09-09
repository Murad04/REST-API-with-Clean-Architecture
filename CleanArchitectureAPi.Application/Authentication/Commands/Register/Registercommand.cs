using CleanArchitectureAPi.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CleanArchitectureAPi.Application.Authentication.Commands.Register;

public record Registercommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;