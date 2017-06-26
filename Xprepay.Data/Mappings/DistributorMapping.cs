using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class DistributorMapping : EntityTypeConfiguration<Distributor>
    {
        public DistributorMapping()
        {
            this.Property(x => x.DistributorAddress).HasMaxLength(500);
            this.Property(x => x.DistributorName).HasMaxLength(200);
            this.Property(x => x.PhoneNum).HasMaxLength(20);
            this.Property(x => x.Contact).HasMaxLength(20);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
