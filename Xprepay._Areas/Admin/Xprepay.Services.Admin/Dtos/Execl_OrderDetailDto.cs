using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Admin.Dtos
{
    /// <summary>
    /// 导出报表模板用
    /// </summary>
    public class Execl_OrderDetailDto
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
        /// 商品数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 购买者姓名
        /// </summary>
        public string BuyerName { get; set; }
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
    }
}
