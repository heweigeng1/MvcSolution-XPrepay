using System.Data.Entity.ModelConfiguration;
using Xprepay.Data;

namespace Xprepay.Data.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.Property(x => x.UserName).HasMaxLength(250);
            this.Property(x => x.Password).HasMaxLength(200);
            this.Property(x => x.NickName).HasMaxLength(200);
            this.Property(x => x.ImageKey).HasMaxLength(250);
            this.Property(x => x.Signature).HasMaxLength(250);
            this.Property(x => x.RegisterIp).HasMaxLength(20);
            this.Property(x => x.RegisterAddress).HasMaxLength(250);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
