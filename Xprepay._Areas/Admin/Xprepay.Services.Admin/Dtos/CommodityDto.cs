using System;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Admin.Dtos
{
    public class CommodityDto:DtoBase
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 价钱
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int? Stock { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StrTime { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public Guid? CategoryId { get; set; }
        public string CnStatus { get { return Enum.GetName(typeof(EnumStatus), Status); } }
    }
}
namespace Xprepay
{
    public static class CommodityDtoExtAdmin
    {
        public static IQueryable<CommodityDto> ToDtos(this IQueryable<Commodity> list)
        {
            return from l in list
                   select new CommodityDto
                   {
                       Id=l.Id,
                       Detail = l.Detail,
                       Name = l.Name,
                       PicUrl = l.PicUrl,
                       Price = l.Price,
                       Remark = l.Remark,
                       Status = l.Status,
                       Stock = l.Stock,
                       CreatedTime=l.CreatedTime,
                       Delflag=l.Delflag,
                       StrTime=l.StrTime,
                       CategoryId=l.CategoryId,
                   };
        }
        public static CommodityDto ToDto(this Commodity entity)
        {
            return AutoMapper.Mapper.Map<CommodityDto>(entity);
        }
    }
}

