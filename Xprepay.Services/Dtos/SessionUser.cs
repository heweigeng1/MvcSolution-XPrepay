﻿using System;
using Xprepay.Data;

namespace Xprepay.Services
{
    public class SessionUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NickName { get; set; }
        public int UserType { get; set; }
        public string[] Roles { get; set; }

        public SessionUser(User user, string[] roles)
        {
            this.Id = user.Id;
            this.Roles = roles;
            this.NickName = user.NickName;
            this.UserType = user.UserType;
        }
    }
}
