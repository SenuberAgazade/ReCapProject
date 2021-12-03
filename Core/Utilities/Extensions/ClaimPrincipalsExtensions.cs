using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Extensions
{
    public static class ClaimPrincipalsExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimPrincipals, string claimType)
        {
            var result = claimPrincipals?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimPrincipals)
        {
            return claimPrincipals?.Claims(ClaimTypes.Role);
        }
    }
}
