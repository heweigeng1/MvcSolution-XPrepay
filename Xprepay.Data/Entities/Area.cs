using System;
using System.Collections.Generic;

namespace Xprepay.Data.Entities
{
    public class Area : EntityBase
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 外键
        /// </summary>
        public Guid? ParentRegionID { get; set; }
        /// <summary>
        /// 自关联父级
        /// </summary>
        public virtual Area FatherArea { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public virtual ICollection<Area> Childs { get; set; }
    }
}
