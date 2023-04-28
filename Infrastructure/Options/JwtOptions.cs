namespace PicPayLite.Infrastructure.Options
{
    public class JwtOptions
    {
        public static readonly string Jwt = "Jwt";
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string SecretKey { get; init; }
    }
}