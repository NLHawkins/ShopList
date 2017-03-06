using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ShopList.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetPrefLocId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("PrefLocId");
            // Test for null to avoid issues during local testing
            return int.Parse(claim.Value);
        }
    }
}