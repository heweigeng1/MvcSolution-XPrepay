using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class OrderDetailMapping : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            this.Property(x => x.CDName).HasMaxLength(200);
            this.Property(x => x.CDPicUrl).HasMaxLength(500);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
