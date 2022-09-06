using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitectureAPi.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userID, string firstname, string lastname)
    {
        var signingCredentials=new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims=new []
        {
            new Claim(JwtRegisteredClaimNames.Sub,userID.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName,lastname),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        };

        var securityToken=new JwtSecurityToken(
            issuer:"CleanArchitectureAPi",
            expires:_dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials:signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
