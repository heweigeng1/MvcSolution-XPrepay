using System;
using System.Collections.Generic;
using System.Linq;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;

namespace Xprepay.Services.Admin.Implementations
{
    public class UserDistributorRLService : ServiceBase,IUserDistributorRLService
    {
        public bool Add(UserDistributorRL entity)
        {
            using (var db=base.NewDB())
            {
                db.UserDistributorRLs.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Del(UserDistributorRL entity)
        {
            using (var db=base.NewDB())
            {
                var model = db.UserDistributorRLs.FirstOrDefault(c => c.UserId == entity.UserId && c.DistributorId == entity.DistributorId);
                db.UserDistributorRLs.Remove(model);
                return db.SaveChanges() > 0;
            }
        }

        public List<DistributorDto> GetUserDistributor(Guid userId)
        {
            using (var db=base.NewDB())
            {
                var data = from drl in db.UserDistributorRLs
                           where drl.UserId == userId
                           from d in db.Distributors
                           where d.Id == drl.DistributorId
                           select d;
                return data.ToDtos().ToList();
            }
        }
    }
}
