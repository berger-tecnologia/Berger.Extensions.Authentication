using Microsoft.IdentityModel.Tokens;

namespace Berger.Extensions.Jwt
{
    public class TokenValidationService : TokenBaseService
    {
        #region Properties
        private TokenValidationParameters Validator { get; set; }
        #endregion

        #region Constructors
        public TokenValidationService()
        {
            this.Validator = Create();
        }
        #endregion

        #region Methods
        public TokenValidationParameters Get()
        {
            return this.Validator;
        }
        public void SetIssuer(string issuer)
        {
            this.Validator.ValidIssuer = issuer;
        }
        public void SetAudience(string audience)
        {
            this.Validator.ValidAudience = audience;
        }
        public void SetKey(string secret)
        {
            this.Validator.IssuerSigningKey = CreateSymmetricSecurityKey(secret);
        }
        private TokenValidationParameters Create(bool checkIssuer = true, bool checkAudience = true, bool checkLifetime = true, bool checkIssuerSigningKey = true)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = checkIssuer,
                ValidateAudience = checkAudience,
                ValidateLifetime = checkLifetime,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = checkIssuerSigningKey
            };
        }
        #endregion
    }
}