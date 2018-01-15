using System;
using System.Linq;
using System.Web;
using Xprepay.Data;
using Xprepay.Data.Enums;
using Xprepay.Services.Dtos;
using Xprepay.Services.SearchCriterias;

namespace Xprepay.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public SessionUser GetSessionUser(Guid userId)
        {
            using (var db = base.NewDB())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                {
                    return null;
                }
                var roleNames = db.Roles.GetUserRoleNames(user.Id);
                var session = new SessionUser(user, roleNames);

                return session;
            }
        }

        public void Login(string username, string password,string url)
        {
            using (var db = base.NewDB())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == username);
                if (user == null)
                {
                    throw new KnownException("用户名或密码不正确!");
                }
                if (CryptoService.Md5HashEncrypt(password) != user.Password)
                {
                    throw new KnownException("用户名或密码不正确!");
                }
                if (!url.ToLower().Contains("moblie"))
                {
                    if (user.UserType!=(int)EnumUserType.后台管理员)
                    {
                        throw new KnownException("非管理员帐号!");
                    }
                }
                user.LastLoginTime = DateTime.Now;
                db.SaveChanges();
            }
        }

        public User Get(Guid id)
        {
            using (var db = base.NewDB())
            {
                return db.Users.Get(id);
            }
        }

        public User Get(string username)
        {
            using (var db = base.NewDB())
            {
                return db.Users.FirstOrDefault(x => x.UserName == username);
            }
        }

        public void Register(string username, string password, bool registerAsAdmin)
        {
            var ip = HttpContext.Current.Request.UserHostAddress;
            var address = IpHelper.GetAddress(ip);
            using (var db = base.NewDB())
            {
                if (db.Users.Any(x => x.UserName == username))
                {
                    throw new KnownException("username already exists");
                }
                var user = new User(username, CryptoService.Md5HashEncrypt(password));
                user.RegisterIp = ip;
                user.RegisterAddress = address;
                db.Users.Add(user);

                if (registerAsAdmin)
                {
                    var role = db.Roles.FirstOrDefault(x => x.Name == Role.Names.SuperAdmin);
                    if (role == null)
                    {
                        Role rl = new Role();
                        rl.NewId();
                        rl.Name = Role.Names.SuperAdmin;
                        db.Roles.Add(rl);
                        db.UserRoleRLs.Add(new UserRoleRL(user.Id, rl.Id));
                    }
                    else
                    {
                        db.UserRoleRLs.Add(new UserRoleRL(user.Id, role.Id));
                    }

                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 后台添加普通用户,无权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add(User user)
        {
            using (var db = base.NewDB())
            {
                user.UserType = (int)EnumUserType.普通用户;
                user.CreatedTime = DateTime.Now;
                user.LastUpdatedTime = DateTime.Now;
                user.RegisterIp = IpHelper.GetAddress(HttpContext.Current.Request.UserHostAddress);
                user.Password = CryptoService.Md5HashEncrypt(user.Password);
                db.Users.Add(user);
                return db.SaveChanges()>0;
            }
        }
        /// <summary>
        /// 修改用户帐号,昵称
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user) {
            using (var db=base.NewDB())
            {
               var entity= db.Users.FirstOrDefault(c => c.Id == user.Id);
                if (entity!=null)
                {
                    entity.UserName = user.UserName;
                    entity.NickName = user.NickName;
                    entity.PhoneNum = user.PhoneNum;
                    entity.LastUpdatedTime = DateTime.Now;
                }
                return db.SaveChanges() > 0;
            }
        }
        public void CompleteRegistration(Guid userId, User user)
        {
            using (var db = base.NewDB())
            {
                var dbUser = db.Users.Get(userId);
                dbUser.UpdateByCompleteRegistration(user);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ChangePassword(User user)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Users.FirstOrDefault(c => c.Id == user.Id);
                if (entity!=null)
                {
                    entity.Password = CryptoService.Md5HashEncrypt(user.Password);
                    entity.LastUpdatedTime = DateTime.Now;
                }
                return db.SaveChanges()>0;
            }
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Users.Find(id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    if (entity.Delflag==(int)EnumDelflag.删除)
                    {
                        entity.Delflag = (int)EnumDelflag.正常;
                    }
                    else
                    {
                        entity.Delflag = (int)EnumDelflag.删除;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }

        public PageResult<UserDto> PageSearch(SCUser model)
        {
            using (var db=base.NewDB())
            {
                var data = db.Users.AsQueryable();
                if (!string.IsNullOrEmpty(model.PhoneNum))
                {
                    data = data.Where(c => c.PhoneNum.Contains(model.PhoneNum));
                }
                if (!string.IsNullOrEmpty(model.UserName))
                {
                    data = data.Where(c => c.UserName.Contains(model.UserName));
                }
                if (model.StrTime!=null)
                {
                    data = data.Where(c => c.CreatedTime >= model.StrTime);
                }
                if (model.EndTime!=null)
                {
                    data = data.Where(c => c.CreatedTime <= model.EndTime);
                }
                return data.ToDtos().ToPageResult(model.Pagination);
            }
        }
    }
}
