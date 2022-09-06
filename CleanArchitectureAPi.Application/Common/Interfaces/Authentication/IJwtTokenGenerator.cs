namespace CleanArchitectureAPi.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userID,string firstname,string lastname);
}