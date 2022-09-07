namespace CleanArchitectureAPi.Application.Common.Interfaces.Authentication;

// IJwtTokenGenerator interface.
public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userID,string firstname,string lastname);
}