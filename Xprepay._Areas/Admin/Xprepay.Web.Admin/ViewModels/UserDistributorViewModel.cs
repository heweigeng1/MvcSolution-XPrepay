using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.ViewModels
{
    public class UserDistributorViewModel : LayoutViewModel
    {
        public Guid Uid { get; set; }
        /// <summary>
        /// 所有店铺
        /// </summary>
        public List<DistributorDto> DList { get; set; } = new List<DistributorDto>();
        /// <summary>
        /// 用户管理店铺
        /// </summary>
        public List<DistributorDto> UserDList { get; set; } = new List<DistributorDto>();
    }
}
