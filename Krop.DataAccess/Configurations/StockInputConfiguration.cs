using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class StockInputConfiguration:BaseConfiguration<StockInput>
    {
        public override void Configure(EntityTypeBuilder<StockInput> builder)
        {
            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0.0m);

            builder.Property(x => x.InvoiceNumber)
                .HasMaxLength(32);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);


            builder.HasOne(x=>x.Product)
                .WithMany(x=>x.StockInputs)
                .HasForeignKey(x=>x.ProductId);

            builder.HasOne(x=>x.Supplier)
                .WithMany(x=>x.StockInputs)
                .HasForeignKey(x=>x.SupplierId);

            builder.HasOne(x=>x.Branch)
                .WithMany(x=>x.StockInputs)
                .HasForeignKey(x=>x.BranchId);

            builder.HasOne(x=>x.AppUser)
                .WithMany(x=>x.StockInputs)
                .HasForeignKey(x=>x.AppUserId);

            base.Configure(builder);
        }
    }
}
