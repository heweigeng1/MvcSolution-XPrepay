using System;
using System.Linq;
using Xprepay.Data;
using Xprepay;
using Xprepay.Services.Admin;
using System.Collections.Generic;
using AutoMapper;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Admin
{
    public class UserDto: DtoBase
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string PhoneNum { get; set; }
        public string ImageKey { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string RegisterAddress { get; set; }
    }
}

namespace Xprepay
{
    public static class UserDtoExtAdmin
    {
        public static IQueryable<UserDto> ToDtos(this IQueryable<User> query)
        {
            return from a in query
                   select new UserDto()
                   {
                       Id = a.Id,
                       UserName = a.UserName,
                       NickName = a.NickName,
                       ImageKey = a.ImageKey,
                       LastLoginTime = a.LastLoginTime,
                       CreatedTime = a.CreatedTime,
                       PhoneNum=a.PhoneNum,
                       Delflag=a.Delflag,
                       RegisterAddress = a.RegisterAddress
                   };
        }
        public static UserDto ToDto(this User user)
        {
            if (user!=null)
            {
                return Mapper.Map<UserDto>(user);
            }
            return new UserDto();
        }
    }
}