namespace Berger.Extensions.Jwt
{
    public class JwtConfig
    {
        public int Expiration { get; init; } = 0;
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public string Audience { get; set; }
        public int RefreshTokenExpiration { get; init; } = 0;
    }
}