using System;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin
{
	public interface IOrderService
    {
        PageResult<OrderDto> Search(OrderSearchCriteria asc, PageRequest request);
        bool Add(Order entity);
        bool Update(Order entity);
        OrderDto Get(Guid id);
        bool Delflag(Guid id);
        bool Status(Guid id);
    }
}

