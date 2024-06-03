using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class ProductionStockExitConfiguration:BaseConfiguration<ProductionStockExit>
    {
        public override void Configure(EntityTypeBuilder<ProductionStockExit> builder)
        {
            builder.Property(x => x.QuantityExit).IsRequired();

           /* builder.HasOne(x => x.Branch)
                .WithMany(x => x.ProductionStockExits)
                .HasForeignKey(x => x.BranchId);*/

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductionStockExits)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Production)
                .WithMany(x => x.ProductionStockExits)
                .HasForeignKey(x => x.ProductionId)
                .OnDelete(DeleteBehavior.Restrict);

            /*builder.HasOne(x => x.AppUser)
                .WithMany(x => x.ProductionStockExits)
                .HasForeignKey(x => x.AppUserId);*/
            base.Configure(builder);
        }
    }
}
