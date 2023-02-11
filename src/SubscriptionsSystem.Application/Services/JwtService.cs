using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using SubscriptionsSystem.Application.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SubscriptionsSystem.Application.Services;

public class JwtService
{
    public static string GenerateToken(IEnumerable<Claim> claims, string securityKey, DateTime expirationDate)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = credentials,
            Expires = expirationDate
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}