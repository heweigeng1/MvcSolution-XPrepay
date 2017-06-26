using System;
using System.Collections.Generic;

namespace Xprepay.Data.Entities
{
    public class Order : EntityBase
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
        /// 配送地址
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 购买人
        /// </summary>
        public Guid BuyId { get; set; }
        public virtual User BuyUser { get; set; }
        /// <summary>
        /// 购买者姓名
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public Guid DistributorId { get; set; }
        /// <summary>
        /// 店铺
        /// </summary>
        public Distributor Distributor { get; set; }
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
        public int OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
