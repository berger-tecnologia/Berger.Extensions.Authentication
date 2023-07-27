namespace Berger.Extensions.Jwt
{
    public class JwtSpecification
    {
        public string Issuer { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int Expiration { get; init; } = 0;
        public int RefreshTokenExpiration { get; init; } = 0;
    }
}