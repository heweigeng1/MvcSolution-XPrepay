using System.Data.Entity.ModelConfiguration;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class DictionaryMapping : EntityTypeConfiguration<Dictionary>
    {
        public DictionaryMapping()
        {
            this.Property(x => x.Code).HasMaxLength(200);
            this.Property(x => x.Title).HasMaxLength(200);
            this.Property(x => x.Class).HasMaxLength(200);
            this.Property(x => x.Style).HasMaxLength(200);
            this.Property(x => x.Description).HasMaxLength(200);
            this.HasOptional(d => d.Parent).WithMany(x => x.Childs).HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
