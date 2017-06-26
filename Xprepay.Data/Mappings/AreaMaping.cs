using Xprepay.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Xprepay.Data.Mappings
{
    public class AreaMaping : EntityTypeConfiguration<Area>
    {
        public AreaMaping()
        {
            this.Property(x => x.Name).IsRequired().HasMaxLength(200);
            this.Property(x => x.AreaCode).HasMaxLength(200);
            this.HasOptional(d => d.FatherArea).WithMany(x=>x.Childs).HasForeignKey(x=>x.ParentRegionID).WillCascadeOnDelete(false); 
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
