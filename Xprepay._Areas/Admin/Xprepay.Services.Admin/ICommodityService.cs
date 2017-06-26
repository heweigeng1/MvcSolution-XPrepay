using System;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin
{
    public interface ICommodityService
    {
        PageResult<CommodityDto> Search(CommoditySearchCriteria asc, PageRequest request);
        bool Add(Commodity commodity);
        bool Update(Commodity commodity);
        CommodityDto Get(Guid id);
        bool Delflag(Guid id);
        bool Status(Guid id);
    }
}
