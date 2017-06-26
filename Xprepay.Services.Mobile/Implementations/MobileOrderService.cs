using System;
using System.Collections.Generic;
using System.Linq;
using Xprepay.Data;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Mobile.Dtos;
using Xprepay.Services.Mobile.SearchCriterias;
using Xprepay.Utilities;


namespace Xprepay.Services.Mobile.Implementations
{
    public class MobileOrderService : ServiceBase, IMobileOrderService
    {
        public bool Add(Order entity)
        {
            using (var db = base.NewDB())
            {
                db.Orders.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db = base.NewDB())
            {
                var entity = db.Orders.Find(id);
                if (entity != null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    if (entity.Delflag == (int)EnumDelflag.正常)
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
            using (var db = base.NewDB())
            {
                var model = db.Orders.Find(entity.Id);
                if (entity != null)
                {

                }
                return db.SaveChanges() > 0;
            }
        }

        public MobileOrderDto Get(Guid id)
        {
            using (var db = base.NewDB())
            {
                return db.Orders.Find(id).ToDto();
            }
        }

        public PageResult<MobileOrderDto> Search(MobileOrderSearchCriteria csc, PageRequest request)
        {
            using (var db = base.NewDB())
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
            using (var db = base.NewDB())
            {
                var entity = db.Orders.Find(id);
                if (entity != null)
                {
                    entity.LastUpdatedTime = DateTime.Now;

                }
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MobileOrderOutput PlaceAnOrder(MobileOrderBindModel model)
        {
            using (var db = base.NewDB())
            {
                MobileOrderOutput output = new MobileOrderOutput();//返回模型
                var commoditys = db.Commoditys.Where(c => c.Status == (int)EnumStatus.上架 && c.Delflag == (int)EnumDelflag.正常).ToList();
                var user = db.Users.Find(model.BuyerId);
                output.Errors = CheckOrder(model.Olist, commoditys);//校验订单
                if (output.Valid)
                {
                    Order order = new Order
                    {
                        Id = Guid.NewGuid(),
                        BuyId = model.BuyerId,
                        DistributorId = model.DistributorId,
                        OrderStatus = (int)EnumOrderStatus.已下单,
                        OrderTime = DateTime.Now,
                        CreatedTime = DateTime.Now,
                        Remark = model.Remark,
                        OrderNum = new OrderHelper().GetOnlyOrderNum(),
                        PhoneNum = user.PhoneNum,
                        BuyerName = user.NickName,
                        DeliveryAddress = db.Distributors.Find(model.DistributorId).DistributorAddress,
                        OrderDetails = new List<OrderDetail>(),//初始化
                        LastUpdatedTime = DateTime.Now,
                    };
                    foreach (var item in model.Olist)//减少库存,并添加orderdetail明细
                    {
                        var entity = commoditys.FirstOrDefault(c => c.Id == item.CommodityId);

                        if (entity != null)
                        {
                            entity.Stock = entity.Stock - item.Count;
                            entity.LastUpdatedTime = DateTime.Now;
                            item.Id = Guid.NewGuid();
                            item.CDName = entity.Name;
                            item.CDPicUrl = entity.PicUrl;
                            item.CDPrice = entity.Price;
                            item.CommodityId = entity.Id;
                            order.OrderDetails.Add(item);
                        }
                    }
                    order.Money = order.OrderDetails.Sum(c => c.Total);
                    db.Orders.Add(order);
                    if (db.SaveChanges() > 0)
                    {
                        output.Order = order.ToDto();
                    }
                    else//添加失败返回一条错误信息
                    {
                        output.Errors.Add(new OrderErrors { ErrorType = (int)EnumErrorsType.系统错误, Message = "下单失败", Name = "order" });
                    }
                }
                return output;
            }
        }
        /// <summary>
        /// 检查库存与商品
        /// </summary>
        /// <param name="olist">订单商品</param>
        /// <param name="clist">商品列表</param>
        /// <returns>订单异常列表</returns>
        public List<OrderErrors> CheckOrder(List<OrderDetail> olist, List<Commodity> clist)
        {
            List<OrderErrors> errors = new List<OrderErrors>();
            foreach (var item in olist)
            {
                var entity = clist.FirstOrDefault(c => c.Id == item.CommodityId);
                if (entity == null)
                {
                    errors.Add(new OrderErrors { ErrorType = 1, Message = $"{item.CDName}已下架", Name = item.CDName });
                    continue;//商品不在列表则退出当此循环
                }
                if (entity.Stock < item.Count)
                {
                    errors.Add(new OrderErrors { ErrorType = 1, Message = $"{item.CDName}库存不足", Name = item.CDName });
                }
            }
            return errors;
        }
    }
}

