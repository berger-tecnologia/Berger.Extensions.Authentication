using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Jwt
{
    public static class AuthorizationConfiguration
    {
        public static void ConfigureJwtHeaders(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString(Standards.Token);

                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Append(Standards.Authorization, Standards.Bearer + token);
                }

                await next();
            });
        }
    }
}