using System.Data.Entity.ModelConfiguration;
using Xprepay.Data.Entities;

namespace Xprepay.Data.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            this.Property(x => x.CategoryName).IsRequired().HasMaxLength(20);
            this.Property(x => x.Delflag).IsRequired();
        }
    }
}
