using System;
using System.Collections.Generic;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Dtos;
using Xprepay.Services.SearchCriterias;

namespace Xprepay.Services.Implementations
{
    public class AreaService :ServiceBase, IAreaService
    {
        public bool Add(Area entity)
        {
            using (var db=base.NewDB())
            {
                entity.Id = Guid.NewGuid();
                db.Areas.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.Areas.Find(id);
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

        public bool Update(Area entity)
        {
            using (var db=base.NewDB())
            {
                var model = db.Areas.Find(entity.Id);
                if (entity!=null)
                {
					
                }
                return db.SaveChanges() > 0;
            }
        }

        public AreaDto Get(Guid id)
        {
            using (var db=base.NewDB())
            {
                return db.Areas.Find(id).ToDto();
            }
        }

        public PageResult<AreaDto> Search(AreaSearchCriteria csc, PageRequest request)
        {
            using (var db=base.NewDB())
            {
                var data = db.Areas.AsQueryable();
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
                if (csc.State!=-99)
                {
                    data = data.Where(c => c.Delflag == csc.State);
                }
                return data.ToDtos().ToPageResult(request);
            }
        }

        public List<AreaDto> GetList()
        {
            using (var db=base.NewDB())
            {
                return db.Areas.Where(c => c.Delflag != (int)EnumDelflag.删除).OrderBy(c=>c.Name).ToDtos().ToList();
            }
        }
    }
}

