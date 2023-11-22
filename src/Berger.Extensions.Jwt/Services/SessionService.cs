using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Berger.Extensions.Abstractions;
using Microsoft.AspNetCore.Http.Features;

namespace Berger.Extensions.Jwt
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _acessor;
        public SessionService(IHttpContextAccessor acessor)
        {
            this._acessor = acessor ?? throw new ArgumentNullException(nameof(acessor));
        }
        public Guid GetGroupSid()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid);

            return Guid.Parse(claim.Value);
        }
        public Guid GetSid()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.Sid);

            return Guid.Parse(claim.Value);
        }
        public string GetName()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.Name);

            return claim != null ? claim.Value : string.Empty;
        }
        public string GetEmail()
        {
            var claim = _acessor.HttpContext.User.FindFirst(ClaimTypes.Email);

            return claim != null ? claim.Value : string.Empty;
        }
        public List<string> GetRole()
        {
            var claim = _acessor.HttpContext.User.FindAll(ClaimTypes.Role);

            return claim != null ? claim.Select(c => c.Value).ToList() : new List<string>();
        }
        public string GetIp()
        {
            var address = _acessor.HttpContext.Features.Get<IHttpConnectionFeature>();

            if (address != null)
                return address.RemoteIpAddress.ToString();
            else
                return string.Empty;
        }
        public void Logoff()
        {
            var ip = GetIp();

            _acessor.HttpContext.Session.Remove("Token");
        }
    }
}