using System.Security.Claims;

namespace Berger.Extensions.Jwt
{
    public interface IJwtService
    {
        Token Issue();
        string Issue(List<Claim> claims, JwtConfig config);
        string RefreshToken(string expiredToken, string refreshToken, JwtConfig config);
    }
}