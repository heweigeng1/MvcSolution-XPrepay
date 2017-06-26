using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {

        }
    }
}
