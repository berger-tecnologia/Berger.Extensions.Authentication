using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Jwt
{
    public class JwtService : IJwtService
    {
        public string Issue(IConfiguration configuration, string email, string role)
        {
            var token = CreateToken(configuration, email, role);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private JwtSecurityToken CreateToken(IConfiguration configuration, string email, string role)
        {
            var jwt = configuration.GetSection(Specifications.Jwt).Get<JwtSpecification>();

            var service = new TokenSecurityService();

            service.SetIssuer(jwt.Issuer);
            service.SetSubject(email, role);
            service.SetAudience(jwt.Audience);
            service.SetCredential(jwt.Secret);
            service.SetExpiration(jwt.Expiration);

            var handler = new JwtSecurityTokenHandler();

            return handler.CreateToken(service.Get()) as JwtSecurityToken;
        }
    }
}