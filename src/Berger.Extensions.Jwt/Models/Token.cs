using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Jwt
{
    public class Token : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public string Name { get; set; }
        public string Issuer { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}