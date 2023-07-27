using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Jwt
{
    public interface IJwtService
    {
        string Issue(IConfiguration configuration, string email, string role);
    }
}