using System;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Services.Admin.SearchCriterias;

namespace Xprepay.Services.Admin.Implementations
{
    public class testService :ServiceBase, ItestService
    {
        public bool Add(test entity)
        {
            using (var db=base.NewDB())
            {
                db.tests.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delflag(Guid id)
        {
            using (var db=base.NewDB())
            {
                var entity = db.tests.Find(id);
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

        public bool Update(test entity)
        {
            using (var db=base.NewDB())
            {
                var model = db.tests.Find(entity.Id);
                if (entity!=null)
                {
					
                }
                return db.SaveChanges() > 0;
            }
        }

        public testDto Get(Guid id)
        {
            using (var db=base.NewDB())
            {
                return db.tests.Find(id).ToDto();
            }
        }

        public PageResult<testDto> Search(testSearchCriteria csc, PageRequest request)
        {
            using (var db=base.NewDB())
            {
                var data = db.tests.AsQueryable();
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
                var entity = db.tests.Find(id);
                if (entity!=null)
                {
                    entity.LastUpdatedTime = DateTime.Now;
                    if (entity.Status==(int)EnumtestStatus.上架)
                    {
                        entity.Status = (int)EnumtestStatus.下架;
                    }
                    else
                    {
                        entity.Status = (int)EnumtestStatus.上架;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }
    }
}

