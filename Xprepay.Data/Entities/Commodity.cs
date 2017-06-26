using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Data.Entities
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class Commodity : EntityBase
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
        /// 单价价钱
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
        /// 上架时间
        /// </summary>
        public DateTime? StrTime { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
