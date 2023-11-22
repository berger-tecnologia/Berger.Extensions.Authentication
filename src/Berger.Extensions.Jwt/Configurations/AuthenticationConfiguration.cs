using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.Jwt
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            // Jwt Service
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}