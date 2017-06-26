using System.Collections.Generic;
using Xprepay.Services.Dtos;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.ViewModels
{
    public class DistributorViewModel : LayoutViewModel
    {
        public List<AreaDto> AreaList { get; set; } = new List<AreaDto>();
    }
}
