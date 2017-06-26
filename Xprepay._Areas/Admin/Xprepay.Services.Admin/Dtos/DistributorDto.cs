using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using System;

namespace Xprepay.Services.Admin.Dtos
{
    public class DistributorDto: DtoBase
    {
        /// <summary>
        /// 供销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 门店地址
        /// </summary>
        public string DistributorAddress { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 最后下单时间
        /// </summary>
        public DateTime? LastOrderTime { get; set; }
        public Guid? AreaId { get; set; }
        public int Status { get; set; }
    }
}

namespace Xprepay
{
    public static class DistributorDtoExtAdmin
    {
        public static IQueryable<DistributorDto> ToDtos(this IQueryable<Distributor> query)
        {
            return from a in query
                   select new DistributorDto()
                   {
                       CreatedTime=a.CreatedTime,
                       Delflag=a.Delflag,
                       DistributorAddress=a.DistributorAddress,
                       DistributorName=a.DistributorName,
                       Id=a.Id,
                       LastOrderTime=a.LastOrderTime,
                       LastUpdatedTime=a.LastUpdatedTime,
                       PhoneNum=a.PhoneNum,
                       Contact=a.Contact,
                       AreaId=a.AreaId,
                       Status=a.Status,
                   };
        }
        public static DistributorDto ToDto(this Distributor entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<DistributorDto>(entity);
            }
            return new DistributorDto();
        }
    }
}

