using System;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin
{
	public interface ICategoryService
    {
        PageResult<CategoryDto> Search(CategorySearchCriteria asc, PageRequest request);
        bool Add(Category entity);
        bool Update(Category entity);
        CategoryDto Get(Guid id);
        bool Delflag(Guid id);
        bool Status(Guid id);
    }
}

