using System;
using Xprepay.Data;

namespace Xprepay.Services
{
    public interface IUserService
    {
        SessionUser GetSessionUser(Guid userId);
        void Login(string username, string password);
        User Get(Guid id);
        User Get(string username);
        void Register(string username, string password, bool registerAsAdmin);
        bool Add(User user);
        bool Update(User user);
        bool ChangePassword(User user);
        bool Delflag(Guid id);
        void CompleteRegistration(Guid userId, User user);
    }
}
