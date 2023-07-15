namespace Berger.Extensions.Authentication
{
    public class Token
    {
        public string Issuer { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresOn { get; set; }
    }
}