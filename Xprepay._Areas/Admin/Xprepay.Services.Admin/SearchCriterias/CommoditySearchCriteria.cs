using System;

namespace Xprepay.Services.Admin.SearchCriterias
{
    public class CommoditySearchCriteria
    {
        /// <summary>
        /// 菜品分类
        /// </summary>
        public Guid? CategoryId { get; set; }
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Search { get; set; }
        /// <summary>
        /// 上下架
        /// </summary>
        public int State { get; set; }
    }
}
