using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            this.Property(x => x.PhoneNum).HasMaxLength(50);
            this.Property(x => x.DeliveryAddress).HasMaxLength(500);
            this.Property(x => x.Remark).HasMaxLength(500);
            this.Property(x => x.BuyerName).HasMaxLength(200);
            this.Property(x => x.OrderNum).HasMaxLength(18);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
