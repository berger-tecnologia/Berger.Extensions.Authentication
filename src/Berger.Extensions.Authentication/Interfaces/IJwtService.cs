using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Authentication
{
    public interface IJwtService
    {
        string Issue(IConfiguration configuration, string email, string role);
    }
}