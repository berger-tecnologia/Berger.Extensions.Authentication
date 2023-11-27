namespace Berger.Extensions.Jwt
{
    public class JwtConfig
    {
        public int Expiration { get; init; } = 0;
        public string Issuer { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int RefreshTokenExpiration { get; init; } = 0;
    }
}