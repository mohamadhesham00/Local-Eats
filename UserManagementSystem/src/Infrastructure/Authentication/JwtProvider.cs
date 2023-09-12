using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserManagementSystem.Src.Core.Entities;

internal sealed class JwtProvider : IJWTProvider
{
    private readonly JwtOptions options;

    public JwtProvider(IOptions<JwtOptions> options) => this.options = options.Value;
    public string Generate(User user)
    {

        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.options.SecretKey)), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            this.options.Issuer,
            this.options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(24),
            signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
