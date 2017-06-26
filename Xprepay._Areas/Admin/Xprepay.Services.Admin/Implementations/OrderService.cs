using System;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin.Implementations
{
    public class OrderService :ServiceBase, IOrderService
    {
        public bool Add(Order entity)
        {
            using (var db=base.NewDB())
            {
                db.Orders.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Orders.Find(id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    if (entity.Delflag==(int)EnumDelflag.正常)
                    {
                        entity.Delflag = (int)EnumDelflag.删除;
                    }
                    else
                    {
                        entity.Delflag = (int)EnumDelflag.正常;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(Order entity)
        {
            using (var db=base.NewDB())
            {
                var model = db.Orders.Find(entity.Id);
                if (entity!=null)
                {
					
                }
                return db.SaveChanges() > 0;
            }
        }

        public OrderDto Get(Guid id)
        {
            using (var db=base.NewDB())
            {
                return db.Orders.Find(id).ToDto();
            }
        }

        public PageResult<OrderDto> Search(OrderSearchCriteria csc, PageRequest request)
        {
            using (var db=base.NewDB())
            {
                var data = db.Orders.AsQueryable();
                if (csc.StarTime!=null)
                {
                    data = data.Where(c => c.CreatedTime >= csc.StarTime);
                }
                if (csc.EndTime!=null)
                {
                    data = data.Where(c => c.CreatedTime <= csc.EndTime);
                }
                if (!string.IsNullOrEmpty(csc.Search))
                {
                    data = data.Where(c => c.OrderNum.Contains(csc.Search));
                }
                return data.ToDtos().ToPageResult(request);
            }
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Status(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Orders.Find(id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                   
                }
                return db.SaveChanges() > 0;
            }
        }
    }
}

