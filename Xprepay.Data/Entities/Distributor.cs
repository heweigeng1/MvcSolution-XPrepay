using System;
using System.Collections;
using System.Collections.Generic;

namespace Xprepay.Data.Entities
{
    public class Distributor : EntityBase
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
        public int Status { get; set; }
        public Guid? AreaId { get; set; }
        public virtual ICollection<Area> Area { get; set; }
    }
}
