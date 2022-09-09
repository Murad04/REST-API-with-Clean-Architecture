using CleanArchitectureAPi.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CleanArchitectureAPi.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;