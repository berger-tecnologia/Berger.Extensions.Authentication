using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Authentication
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
            var jwt = configuration.GetSection("Jwt").Get<JwtSpecification>();

            var service = new TokenSecurityService();

            service.SetSubject(email, role);
            service.SetIssuer(jwt.Issuer);
            service.SetAudience(jwt.Audience);
            service.SetExpiration(jwt.Expiration);
            service.SetCredential(jwt.Secret);

            var handler = new JwtSecurityTokenHandler();

            return handler.CreateToken(service.Get()) as JwtSecurityToken;
        }
    }
}