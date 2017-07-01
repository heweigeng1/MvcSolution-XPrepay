using System;
using System.Data.Entity;
using Xprepay.Data.Enums;

namespace Xprepay.Data
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    public class Init: DropCreateDatabaseIfModelChanges<XprepayDbContext>
    {
        protected override void Seed (XprepayDbContext context)
        {
            var role = context.Roles.Add(new Role
            {
                CreatedTime=DateTime.Now,
                Id=Guid.NewGuid(),
                LastUpdatedTime=DateTime.Now,
                Name="admin",
            });
            var user = context.Users.Add(new User
            {
                Id=Guid.NewGuid(),
                CreatedTime=DateTime.Now,
                NickName = "超级管理员",
                Age = 25,
                UserType=(int)EnumUserType.后台管理员,
                Gender = Gender.Male,
                Password = CryptoService.Md5HashEncrypt("123456"),
                RegisterIp = "192.168.0.8",
                UserName = "admin"
            });
            context.UserRoleRLs.Add(new UserRoleRL
            {
                Id=Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                LastUpdatedTime = DateTime.Now,
                RoleId = role.Id,
                UserId = user.Id,
            });
            context.SaveChanges();
        }
    }
}
