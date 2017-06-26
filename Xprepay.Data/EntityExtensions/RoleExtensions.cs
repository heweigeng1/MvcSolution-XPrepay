using System;
using System.Linq;
using Xprepay.Data;

namespace Xprepay
{
    public static class RoleExtensions
    {
        public static IQueryable<Role> WhereByUsername(this IQueryable<Role> query, string username)
        {
            var query2 = from a in query
                         from b in a.UserRoleRLs
                         where b.User.UserName == username
                         select a;
            return query2.Distinct();
        }

        public static string[] GetUserRoleNames(this IQueryable<Role> query, Guid userId)
        {
            var query2 = from a in query
                         from b in a.UserRoleRLs
                         where b.UserId == userId
                         select a.Name;
            return query2.Distinct().ToArray();
        }
    }
}
