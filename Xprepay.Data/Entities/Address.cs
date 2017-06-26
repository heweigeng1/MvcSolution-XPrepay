using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Data.Entities
{
    /// <summary>
    /// 地址表
    /// </summary>
    public class Address:EntityBase
    {
        public Guid FormId { get; set; }
        public string AddressPath { get; set; }
        public string PhoneNum { get; set; }
        public string Remark { get; set; }
    }
}
