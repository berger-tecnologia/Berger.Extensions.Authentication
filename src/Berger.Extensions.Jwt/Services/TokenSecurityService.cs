using Microsoft.IdentityModel.Tokens;

namespace Berger.Extensions.Jwt
{
    public class TokenSecurityService : TokenBaseService, IToken<SecurityTokenDescriptor>
    {
        #region Properties
        private SecurityTokenDescriptor Descriptor { get; set; }
        #endregion

        #region Constructors
        public TokenSecurityService()
        {
            this.Descriptor = CreateDescriptor();
        }
        #endregion

        #region Methods
        public SecurityTokenDescriptor Get()
        {
            return this.Descriptor;
        }
        public void SetCredential(string secret)
        {
            Descriptor.SigningCredentials = CreateSigningCredentials(secret);
        }
        public void SetAudience(string audience)
        {
            Descriptor.Audience = audience;
        }
        public void SetIssuer(string issuer)
        {
            Descriptor.Issuer = issuer;
        }
        public void SetSubject(string email, string role)
        {
            Descriptor.Subject = CreateClaims(Claims.User, email, role);
        }
        public void SetExpiration(int expiration)
        {
            Descriptor.Expires = Calculate(expiration);
        }
        private SecurityTokenDescriptor CreateDescriptor()
        {
            return new SecurityTokenDescriptor();
        }
        #endregion
    }
}