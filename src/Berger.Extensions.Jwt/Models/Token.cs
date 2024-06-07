using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Jwt
{
    public class Token : BaseEntity
    {
        public Guid EnvironmentId { get; set; }
        public Guid EntityTypeId { get; set; }
        public Guid? EntityId { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresOn { get; set; }
    }
}