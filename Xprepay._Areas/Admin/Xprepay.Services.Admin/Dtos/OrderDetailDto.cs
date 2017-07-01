using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Admin.Dtos
{
    public class OrderDetailDto : DtoBase
    {
        public int Count { get; set; }
        /// <summary>
        /// 商品价钱
        /// </summary>
        public decimal? CDPrice { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal? Total { get { return CDPrice * Count; } }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CDName { get; set; }
        /// <summary>
        /// 商品图
        /// </summary>
        public string CDPicUrl { get; set; }
    }
}
namespace Xprepay
{
    public static class OrderDetailDtoExtAdmin
    {
        public static IQueryable<OrderDetailDto> ToDtos(this IQueryable<OrderDetail> query)
        {
            return from a in query
                   select new OrderDetailDto()
                   {
                       CDName=a.CDName,
                       CDPicUrl=a.CDPicUrl,
                       CDPrice=a.CDPrice,
                       Count=a.Count,
                       CreatedTime=a.CreatedTime,
                       Delflag=a.Delflag,
                       Id=a.Id,
                       LastUpdatedTime=a.LastUpdatedTime
                   };
        }
        public static OrderDetailDto ToDto(this OrderDetail entity)
        {
            if (entity != null)
            {
                return Mapper.Map<OrderDetailDto>(entity);
            }
            return new OrderDetailDto();
        }
        public static OrderDto Bulid(this OrderDto data, XprepayDbContext db)
        {
            data.OrderDetails = db.OrderDetails.Where(c => c.OrderId == data.Id).ToDtos().ToList();
            return data;
        }
    }
}
