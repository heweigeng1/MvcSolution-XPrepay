using System;

namespace Xprepay.Services.Admin
{
    public class UserSearchCriteria
    {
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Search { get; set; }
        /// <summary>
        /// 是否伪删除
        /// </summary>
        public int State { get; set; }
    }
}
