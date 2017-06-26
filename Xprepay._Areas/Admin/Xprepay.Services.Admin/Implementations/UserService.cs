using System;
using System.Linq;
using Xprepay.Data;
using Xprepay.Data.Enums;

namespace Xprepay.Services.Admin
{
    public class UserService : ServiceBase, IUserService
    {
        public PageResult<UserDto> Search(UserSearchCriteria criteria, PageRequest request)
        {
            using (var db = base.NewDB())
            {
                var data = db.Users.AsQueryable();
                if (criteria.StarTime.HasValue)
                {
                    data = data.Where(c => c.CreatedTime >= criteria.StarTime);
                }
                if (criteria.EndTime.HasValue)
                {
                    data = data.Where(c => c.CreatedTime <= criteria.EndTime);
                }
                if (!string.IsNullOrEmpty(criteria.Search))
                {
                    data = data.Where(c => c.NickName.Contains(criteria.Search));
                }
                if (criteria.State!=-99)//全部数据
                {
                    data = data.Where(c => c.Delflag == criteria.State);
                }
                return data
                    .ToDtos()
                    .ToPageResult(request);
            }
        }
    }
}
