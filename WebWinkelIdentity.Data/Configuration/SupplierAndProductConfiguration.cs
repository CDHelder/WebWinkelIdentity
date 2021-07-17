using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebWinkelIdentity.Core;

namespace WebWinkelIdentity.Data.Configuration
{
    public class SupplierAndProductConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {

        }
    }
}
