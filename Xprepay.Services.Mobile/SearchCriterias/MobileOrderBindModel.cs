using System;
using System.Collections.Generic;
using Xprepay.Data;
using Xprepay.Data.Entities;
using System.Linq;
using Xprepay.Data.Enums;
using Xprepay.Services.Mobile.Dtos;

namespace Xprepay.Services.Mobile.SearchCriterias
{
    /// <summary>
    /// 订购列表
    /// </summary>
    public class MobileOrderBindModel
    {
        /// <summary>
        /// 下单人ID
        /// </summary>
        public Guid BuyerId { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public Guid DistributorId { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 订单商品列表
        /// </summary>
        public List<OrderDetail> Olist { get; set; } = new List<OrderDetail>();
    }
    /// <summary>
    /// 返回订单错误列表模型
    /// </summary>
    public class MobileOrderOutput
    {
        public bool Valid { get { return Errors == null || Errors.Count == 0; } }
        public List<OrderErrors> Errors { get; set; }
        public MobileOrderDto Order { get; set; }
    }
}
