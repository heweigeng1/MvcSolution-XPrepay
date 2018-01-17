using System;
using Xprepay.Data;
using Xprepay.Services.Dtos;
using Xprepay.Services.SearchCriterias;

namespace Xprepay.Services
{
    public interface IUserService
    {
        SessionUser GetSessionUser(Guid userId);
        void Login(string username, string password,string url);
        User Get(Guid id);
        User Get(string username);
        void Register(string username, string password, bool registerAsAdmin);
        bool Add(User user);
        bool Update(User user);
        bool ChangePassword(User user);
        bool Delflag(Guid id);
        void CompleteRegistration(Guid userId, User user);
        PageResult<UserDto> PageSearch(SCUser model);
        void ResetPassword(Guid id);
    }
}
