using System.Data.Entity.ModelConfiguration;
using Xprepay.Data;

namespace Xprepay.Data.Mappings
{
    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
