using System;
using System.Collections.Generic;
using Xprepay.Data;
using Xprepay.Data.Entities;
using Xprepay.Services.Mobile.Dtos;
using Xprepay.Services.Mobile.SearchCriterias;

namespace Xprepay.Services.Mobile
{
	public interface IMobileOrderService
    {
        PageResult<MobileOrderDto> Search(MobileOrderSearchCriteria asc, PageRequest request);
        bool Add(Order entity);
        bool Update(Order entity);
        MobileOrderDto Get(Guid id);
        bool Delflag(Guid id);
        bool Status(Guid id);
        MobileOrderOutput PlaceAnOrder(MobileOrderBindModel model);
        List<OrderErrors> CheckOrder(List<OrderDetail> list, List<Commodity> clist);
    }
}

