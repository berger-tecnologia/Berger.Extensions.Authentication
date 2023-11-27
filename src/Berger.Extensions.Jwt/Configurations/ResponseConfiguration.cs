using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Berger.Extensions.Jwt
{
    public static class ResponseConfiguration
    {
        public static void ConfigureResponse(this IApplicationBuilder app, ILogger logger)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                finally
                {
                    var request = context.Request;
                    var response = context.Response;

                    logger.LogInformation($"Request Information: \n" +
                                          $"Schema:{request.Scheme} \n" +
                                          $"Host: {request.Host} \n" +
                                          $"Path: {request.Path} \n" +
                                          $"QueryString: {request.QueryString} \n" +
                                          $"Response Status Code: {response.StatusCode}");

                    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                        response.Redirect("/accounts/signin");
                    else if (response.StatusCode == (int)HttpStatusCode.Forbidden)
                        response.Redirect("/accounts/forbidden");
                    else if (response.StatusCode == (int)HttpStatusCode.NotFound)
                        response.Redirect("/notfound");
                }
            });
        }
    }
}