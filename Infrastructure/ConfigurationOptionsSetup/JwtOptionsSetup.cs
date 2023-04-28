using Microsoft.Extensions.Options;
using PicPayLite.Infrastructure.Options;

namespace PicPayLite.Infrastructure.ConfigurationOptionsSetup
{
    public class JwtOptionsSetup: IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(JwtOptions.Jwt).Bind(options);
        }
    }
}