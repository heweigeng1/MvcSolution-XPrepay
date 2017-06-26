using System.Collections.Generic;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.ViewModels
{
    public class CommodityViewModel : LayoutViewModel
    {
        public CommodityDto Commodity { get; set; } = new CommodityDto();
        public List<CategoryDto> CategoryList { get; set; } = new List<CategoryDto>();
    }
}
