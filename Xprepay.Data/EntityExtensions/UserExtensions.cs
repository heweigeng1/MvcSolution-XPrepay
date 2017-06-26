using System;
using System.Linq;
using Xprepay.Data;

namespace Xprepay
{
    public static class UserExtensions
    {
        public static IQueryable<User> WhereByKeyword(this IQueryable<User> query, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return query;
            }
            return from a in query
                where a.NickName.Contains(keyword)
                      || a.UserName.Contains(keyword)
                select a;
        }
        
        
        public static string GetNickName(this IQueryable<User> query, Guid userId)
        {
            return query.Where(x => x.Id == userId).Select(x => x.NickName).FirstOrDefault();
        }
    }
}
