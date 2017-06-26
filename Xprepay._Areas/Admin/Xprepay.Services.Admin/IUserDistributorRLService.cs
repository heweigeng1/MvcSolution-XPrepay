using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin.Dtos;

namespace Xprepay.Services.Admin
{
   public interface IUserDistributorRLService
    {
        bool Add(UserDistributorRL entity);
        bool Del(UserDistributorRL entity);
        List<DistributorDto>GetUserDistributor (Guid userId);
    }
}
