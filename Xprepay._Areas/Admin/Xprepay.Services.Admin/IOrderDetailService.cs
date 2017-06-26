using System.Collections.Generic;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin
{
    public interface IOrderDetailService
    {
        List<Execl_OrderDetailDto> GetOrderDetail(OrderSearchCriteria csc);
        string SaveToExcel(List<Execl_OrderDetailDto> data,string fileName);
    }
}
