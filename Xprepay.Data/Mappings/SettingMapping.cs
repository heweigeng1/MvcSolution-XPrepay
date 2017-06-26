using System.Data.Entity.ModelConfiguration;
using Xprepay.Data;

namespace Xprepay.Data.Mappings
{
    public class SettingMapping : EntityTypeConfiguration<Setting>
    {
        public SettingMapping()
        {
            this.Property(x => x.Key).IsRequired().HasMaxLength(100);
            this.Property(x => x.Notes).HasMaxLength(250);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
