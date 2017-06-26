using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Services.Mobile.Dtos;
using Xprepay.Data.Entities;
using System;
using System.Collections.Generic;

namespace Xprepay.Services.Mobile.Dtos
{
    public class MobileOrderDto: DtoBase
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNum { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal? Money { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 购买人
        /// </summary>
        public Guid BuyId { get; set; }
        /// <summary>
        /// 购买者姓名
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public Guid AddressId { get; set; }
        /// <summary>
        /// 配送地址
        /// </summary>
        public virtual Address Address { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? OrderTime { get; set; }
    }
}

namespace Xprepay
{
    public static class MobileOrderDtoExtAdmin
    {
        public static IQueryable<MobileOrderDto> ToDtos(this IQueryable<Order> query)
        {
            return from a in query
                   select new MobileOrderDto()
                   {
                       BuyerName = a.BuyerName,
                       BuyId = a.BuyId,
                       CreatedTime = a.CreatedTime,
                       Delflag = a.Delflag,
                       DeliveryAddress = a.DeliveryAddress,
                       DeliveryTime = a.DeliveryTime,
                       Id = a.Id,
                       LastUpdatedTime = a.LastUpdatedTime,
                       Money = a.Money,
                       OrderNum = a.OrderNum,
                       OrderTime = a.OrderTime,
                       PhoneNum = a.PhoneNum,
                       Remark = a.Remark
                   };
        }
        public static MobileOrderDto ToDto(this Order entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<MobileOrderDto>(entity);
            }
            return new MobileOrderDto();
        }
    }
}

