using Microsoft.Extensions.Options;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "JWT";
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions jwtOptions)
    {
        _configuration.GetSection(SectionName).Bind(jwtOptions);
    }

}