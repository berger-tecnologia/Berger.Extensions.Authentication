using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace Berger.Extensions.Jwt
{
    public static class AuthorizationConfiguration
    {
        public static void ConfigureHeaders(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");

                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }

                await next();
            });
        }
    }
}