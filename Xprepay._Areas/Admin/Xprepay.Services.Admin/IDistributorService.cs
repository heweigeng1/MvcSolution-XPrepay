using System;
using System.Collections.Generic;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin
{
	public interface IDistributorService
    {
        PageResult<DistributorDto> Search(DistributorSearchCriteria asc, PageRequest request);
        bool Add(Distributor entity);
        bool Update(Distributor entity);
        DistributorDto Get(Guid id);
        bool Delflag(Guid id);
        bool Status(Guid id);
        List<DistributorDto> GetList();
    }
}

