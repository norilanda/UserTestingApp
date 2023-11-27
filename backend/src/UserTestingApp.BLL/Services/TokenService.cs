using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.BLL.Options;

namespace UserTestingApp.BLL.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;

    public TokenService(JwtOptions jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }

    public string GenerateAccessToken(long userId)
    {
        var claims = new []
        {
            new Claim("id", userId.ToString())
        };

        var now = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(_jwtOptions.Lifetime)),
                signingCredentials: new SigningCredentials(
                    JwtOptions.GetSymmetricSecurityKey(_jwtOptions.SecretKey), _jwtOptions.SecurityAlgorithm));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}
