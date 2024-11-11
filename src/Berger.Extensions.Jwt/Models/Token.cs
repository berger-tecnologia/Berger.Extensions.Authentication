using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Jwt
{
    public class Token : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresOn { get; set; }
    }
}