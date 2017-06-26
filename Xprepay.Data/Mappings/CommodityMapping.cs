using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class CommodityMapping : EntityTypeConfiguration<Commodity>
    {
        public CommodityMapping()
        {
            this.Property(x => x.Detail).HasMaxLength(500);
            this.Property(x => x.PicUrl).HasMaxLength(500);
            this.Property(x => x.Name).HasMaxLength(200);
            this.Property(x => x.Remark).HasMaxLength(500);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
