using System;
using System.Collections.Generic;

namespace Xprepay.Data
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }
        public string ImageKey { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 用户类型,管理员,普通用户
        /// </summary>
        public int UserType { get; set; }
        public string Signature { get; set; }
        public Gender Gender { get; set; }
        public string RegisterIp { get; set; }
        public string RegisterAddress { get; set; }
        public DateTime? LastLoginTime { get; set; }
        
        public virtual ICollection<UserRoleRL> UserRoleRLs { get; set; }
        
        public User()
        {
            this.Id = Guid.NewGuid();
            this.Gender = Gender.Unknown;
        }

        public User(string username, string password) : this()
        {
            this.UserName = username;
            this.Password = password;
            this.NickName = username.Substring(0, username.IndexOf("@"));
        }

        public void UpdateByCompleteRegistration(User user)
        {
            this.NickName = user.NickName;
            this.Signature = user.Signature;
            this.Birthday = user.Birthday;
            this.Gender = user.Gender;
            this.ImageKey = user.ImageKey;
        }
    }
}
