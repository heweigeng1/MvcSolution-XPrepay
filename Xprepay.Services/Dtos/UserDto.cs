using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data;
using Xprepay.Data.Enums;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Dtos
{
    public class UserDto : DtoBase
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public string UserTypeText
        {
            get
            {
                return Enum.GetName(typeof(EnumUserType), UserType);
            }
        }
    }
}
namespace Xprepay
{
    public static class UserDtoExt
    {
        public static IQueryable<UserDto> ToDtos(this IQueryable<User> query)
        {
            return from item in query
                   select new UserDto
                   {
                       Id=item.Id,
                       UserType=item.UserType,
                       CreatedTime=item.CreatedTime,
                       Delflag=item.Delflag,
                       LastUpdatedTime=item.LastUpdatedTime,
                       NickName=item.NickName,
                       PhoneNum=item.PhoneNum,
                       UserName=item.UserName,
                       Email=item.Email
                   };
        }
        public static UserDto ToDto(this User model)
        {
            return Mapper.Map<UserDto>(model);
        }
    }
}
