using System.Net;
using Microsoft.AspNetCore.Builder;

namespace Berger.Extensions.Authentication
{
    public static class ResponseConfiguration
    {
        public static void ConfigureResponse(this IApplicationBuilder app)
        {
            app.UseStatusCodePages
            (
                async context =>
                {
                    var _context = context.HttpContext;

                    if (_context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                        _context.Response.Redirect("/accounts/signin");

                    if (_context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                        _context.Response.Redirect("/accounts/forbidden");

                    if (_context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                        _context.Response.Redirect("/notfound");
                }
            );
        }
    }
}