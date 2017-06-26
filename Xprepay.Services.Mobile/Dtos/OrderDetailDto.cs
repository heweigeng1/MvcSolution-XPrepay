using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Mobile.Dtos
{
    public class OrderDetailDto: DtoBase
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid CommodityId { get; set; }
        public virtual Commodity Commodity { get; set; }
        public int Count { get; set; }
        /// <summary>
        /// 商品价钱
        /// </summary>
        public decimal? CDPrice { get; set; }
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
