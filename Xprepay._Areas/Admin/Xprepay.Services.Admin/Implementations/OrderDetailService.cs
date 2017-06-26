using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin.Implementations
{
    public class OrderDetailService : ServiceBase, IOrderDetailService
    {
        public List<Execl_OrderDetailDto> GetOrderDetail(OrderSearchCriteria csc)
        {
            using (var db=base.NewDB())
            {
                var data = db.Orders.AsQueryable();
                if (csc.StarTime != null)
                {
                    data = data.Where(c => c.CreatedTime >= csc.StarTime);
                }
                if (csc.EndTime != null)
                {
                    data = data.Where(c => c.CreatedTime <= csc.EndTime);
                }
                if (!string.IsNullOrEmpty(csc.Search))
                {
                    data = data.Where(c => c.OrderNum.Contains(csc.Search));
                }
                return (from o in data
                            from od in db.OrderDetails
                            where o.Id == od.OrderId
                            select new Execl_OrderDetailDto
                            {
                                Remark = o.Remark,
                                Money = o.Money,
                                OrderNum = o.OrderNum,
                                PhoneNum = o.PhoneNum,
                                Count = od.Count,
                                CDName = od.CDName,
                                BuyerName = o.BuyerName,
                                DeliveryAddress = o.DeliveryAddress,
                                DeliveryTime = o.DeliveryTime
                            }).ToList();
            }
        }

        public string SaveToExcel(List<Execl_OrderDetailDto> data, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
