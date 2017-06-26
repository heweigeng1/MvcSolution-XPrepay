using System;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin.Implementations
{
    public class CommodityService :ServiceBase, ICommodityService
    {
        public bool Add(Commodity commodity)
        {
            using (var db=base.NewDB())
            {
                commodity.Id = Guid.NewGuid();
                db.Commoditys.Add(commodity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Commoditys.Find(id);
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

        public bool Update(Commodity commodity)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Commoditys.Find(commodity.Id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    entity.CategoryId = commodity.CategoryId;
                    entity.Name = commodity.Name;
                    entity.PicUrl = commodity.PicUrl;
                    entity.Price = commodity.Price;
                    entity.Remark = commodity.Remark;
                    entity.Status = commodity.Status;
                    entity.Stock = commodity.Stock;
                }
                return db.SaveChanges() > 0;
            }
        }

        public CommodityDto Get(Guid id)
        {
            using (var db=base.NewDB())
            {
                return db.Commoditys.Find(id).ToDto();
            }
        }

        public PageResult<CommodityDto> Search(CommoditySearchCriteria csc, PageRequest request)
        {
            using (var db=base.NewDB())
            {
                var data = db.Commoditys.AsQueryable();
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
                    data = data.Where(c => c.Name.Contains(csc.Search));
                }
                if (csc.CategoryId!=null)
                {
                    data = data.Where(c => c.CategoryId==csc.CategoryId);
                }
                if (csc.State!=-99)//全部
                {
                    data = data.Where(c => c.Status == csc.State);
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
                var entity = db.Commoditys.Find(id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    if (entity.Status==(int)EnumStatus.上架)
                    {
                        entity.Status = (int)EnumStatus.下架;
                    }
                    else
                    {
                        entity.Status = (int)EnumStatus.上架;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }
    }
}
