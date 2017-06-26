using System;

namespace Xprepay.Data.Entities
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderDetail : EntityBase
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
