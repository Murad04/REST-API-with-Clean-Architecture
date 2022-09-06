using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitectureAPi.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private JwtSettings _jwtSettings;
    private IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Guid userID, string firstname, string lastname)
    {
        var signingCredentials=new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)
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
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            expires:_dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials:signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
