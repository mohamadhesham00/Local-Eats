using Microsoft.Extensions.Options;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "JWT";
    private readonly IConfiguration configuration;

    public JwtOptionsSetup(IConfiguration configuration) => this.configuration = configuration;

    public void Configure(JwtOptions options) => this.configuration.GetSection(SectionName).Bind(options);

}
