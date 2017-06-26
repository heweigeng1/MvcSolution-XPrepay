using System.Data.Entity.ModelConfiguration;
using Xprepay.Data;

namespace Xprepay.Data.Mappings
{
    public class ImageMapping : EntityTypeConfiguration<Image>
    {
        public ImageMapping()
        {
            this.Property(x => x.Key).IsRequired().HasMaxLength(200);
            this.Property(x => x.Name).IsRequired().HasMaxLength(200);
            this.Property(x => x.OriginalPath).IsRequired().HasMaxLength(200);
            this.Property(x => x.Delflag).IsRequired();

        }
    }
}
