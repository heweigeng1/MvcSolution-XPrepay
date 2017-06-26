using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class UserDitributorRLMapping : EntityTypeConfiguration<UserDistributorRL>
    {
        public UserDitributorRLMapping()
        {
            this.HasKey(x => new { x.UserId, x.DistributorId });
        }
    }
}
