using System;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin
{
	public interface ItestService
    {
        PageResult<testDto> Search(testSearchCriteria asc, PageRequest request);
        bool Add(test entity);
        bool Update(test entity);
        testDto Get(Guid id);
        bool Delflag(Guid id);
        bool Status(Guid id);
    }
}

