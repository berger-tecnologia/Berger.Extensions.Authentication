using Berger.Extensions.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Berger.Extensions.Jwt
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
            var jwt = configuration.GetSection("Jwt").Get<JwtConfig>();

            if (jwt is null)
                throw new ArgumentNullException(nameof(jwt));

            services.AddSession(options =>
            {
                options.Cookie.Name = jwt.Issuer;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromHours(12);

                // TODO: Adicionar Timespan no config.
            });

            var validator = new TokenValidationService();

            validator.SetKey(jwt.Secret);
            validator.SetIssuer(jwt.Issuer);
            validator.SetAudience(jwt.Audience);

            services.AddAuthentication
            (
                e =>
                {
                    //e.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
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
                auth.AddPolicy(Standards.Bearer, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());
            });

            return services;
        }
    }
}