using System.Security.Claims;

namespace Berger.Extensions.Authentication
{
    public static class ClaimHelper
    {
        public static Guid? Get(this ClaimsPrincipal claims, string claimType)
        {
            var element = claims.FindFirst(claimType);

            if (element is not null)
            {
                if (Guid.TryParse(element.Value, out Guid id))
                    return id;
            }

            return null;
        }
        public static bool IsInRole(this ClaimsPrincipal claims, string role) => claims.IsInRole(role);
        public static bool IsNotInRole(this ClaimsPrincipal claims, string role) => !claims.IsInRole(role);
        public static bool IsOwner<TDestination>(this TDestination entity, ClaimsPrincipal claims)
        {
            throw new NotImplementedException();
        }
        public static bool IsAutenticated(this ClaimsPrincipal claims)
        {
            var userID = claims.Get(ClaimTypes.Sid) ?? Guid.Empty;

            return userID != Guid.Empty;
        }
        public static bool IsInGroup(this ClaimsPrincipal claims)
        {
            var groupSid = claims.Get(ClaimTypes.GroupSid) ?? Guid.Empty;

            return groupSid != Guid.Empty;
        }
    }
}