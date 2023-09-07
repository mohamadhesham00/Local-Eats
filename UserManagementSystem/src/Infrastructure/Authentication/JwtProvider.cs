using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserManagementSystem.Src.Core.Entities;

internal sealed class JwtProvider : IJWTProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options) {
        _options = options.Value;
    }
    public string Generate(User user) {

        var claims = new Claim[] 
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}