using System;

namespace Xprepay.Services.Admin.SearchCriterias
{
    public class DistributorSearchCriteria
    {
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Search { get; set; }
        /// <summary>
        /// 上下架
        /// </summary>
        public int State { get; set; }
    }
}

