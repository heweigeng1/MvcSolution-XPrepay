using System.Security.Principal;
using Xprepay.Data;

namespace Xprepay
{
    public static class PrincipalExtensions
    {
        public static bool IsSuperAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(Role.Names.SuperAdmin);
        }
    }
}
