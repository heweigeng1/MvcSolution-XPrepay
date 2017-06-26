using System;
using System.Collections.Generic;
using Xprepay.Data.Entities;
using Xprepay.Services.Dtos;
using Xprepay.Services.SearchCriterias;

namespace Xprepay.Services
{
	public interface IAreaService
    {
        PageResult<AreaDto> Search(AreaSearchCriteria asc, PageRequest request);
        bool Add(Area entity);
        bool Update(Area entity);
        AreaDto Get(Guid id);
        bool Delflag(Guid id);
        List<AreaDto> GetList();
    }
}

