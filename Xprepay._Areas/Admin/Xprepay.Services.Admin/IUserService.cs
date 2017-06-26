using System;
using Xprepay.Data;

namespace Xprepay.Services.Admin
{
    public interface IUserService
    {
        PageResult<UserDto> Search(UserSearchCriteria criteria, PageRequest request);
    }
}
