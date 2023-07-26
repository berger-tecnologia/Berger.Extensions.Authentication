using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Berger.Extensions.Authentication
{
    public static class JwtConfiguration
    {
        public static IServiceCollection ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure(configuration)
                .ConfigureAuthorization();
        }

        private static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = configuration.GetSection("Jwt").Get<JwtSpecification>();

            var validator = new TokenValidationService();

            validator.SetKey(jwt.Secret);
            validator.SetIssuer(jwt.Issuer);
            validator.SetAudience(jwt.Audience);

            services.AddAuthentication
            (
                e =>
                {
                    e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    //e.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(e =>
                {
                    e.SaveToken = true;
                    e.RequireHttpsMetadata = false;
                    e.TokenValidationParameters = validator.Get();
                }
            );

            return services;
        }

        private static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());
            });

            return services;
        }
    }
}