namespace Berger.Extensions.Jwt
{
    public interface IToken<T> where T : class
    {
        public T Get();
        public void SetCredential(string secret);
        public void SetIssuer(string issuer);
        public void SetAudience(string audience);
        public void SetExpiration(int expiration);
    }
}