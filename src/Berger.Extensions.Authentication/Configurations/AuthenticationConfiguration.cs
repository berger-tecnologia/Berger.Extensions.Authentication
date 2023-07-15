using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.Authentication
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            // Jwt Service
            services.AddScoped<IJwtService, JwtService>();

            // Session Service
            services.AddScoped<ISessionService, SessionService>();

            return services;
        }
    }
}