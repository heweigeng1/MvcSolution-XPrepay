using System;
using System.Collections.Generic;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin.Implementations
{
    public class DistributorService :ServiceBase, IDistributorService
    {
        public bool Add(Distributor entity)
        {
            using (var db=base.NewDB())
            {
                entity.Id = Guid.NewGuid();
                db.Distributors.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Distributors.Find(id);
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

        public bool Update(Distributor entity)
        {
            using (var db=base.NewDB())
            {
                var model = db.Distributors.Find(entity.Id);
                if (model!=null)
                {
                    model.DistributorAddress = entity.DistributorAddress;
                    model.DistributorName = entity.DistributorName;
                    model.LastOrderTime = entity.LastOrderTime;
                    model.LastUpdatedTime = DateTime.Now;
                    model.PhoneNum = entity.PhoneNum;
                    model.Status = entity.Status;
                }
                return db.SaveChanges() > 0;
            }
        }

        public DistributorDto Get(Guid id)
        {
            using (var db=base.NewDB())
            {
                return db.Distributors.Find(id).ToDto();
            }
        }

        public PageResult<DistributorDto> Search(DistributorSearchCriteria csc, PageRequest request)
        {
            using (var db=base.NewDB())
            {
                var data = db.Distributors.AsQueryable();
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
                    data = data.Where(c => c.DistributorName.Contains(csc.Search));
                }
                if (csc.State!=-99)//全部
                {
                    data = data.Where(c => c.Status==csc.State);
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
                var entity = db.Distributors.Find(id);
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

        public List<DistributorDto> GetList()
        {
            using (var db=base.NewDB())
            {
                return db.Distributors.Where(c => c.Delflag != (int)EnumDelflag.删除).ToDtos().ToList();
            }
        }
    }
}

