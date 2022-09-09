using CleanArchitectureAPi.Domain.Entities;

namespace CleanArchitectureAPi.Application.Authentication.Common;

public record AuthenticationResult(Users User,string Token);