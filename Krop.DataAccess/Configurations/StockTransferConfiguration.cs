using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class StockTransferConfiguration : BaseConfiguration<StockTransfer>
    {
        public override void Configure(EntityTypeBuilder<StockTransfer> builder)
        {
            builder.Property(x => x.InvoiceNumber)
                .HasMaxLength(32);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.HasOne(x => x.SenderBranch)
                .WithMany(x => x.SenderStockTransfers)
                .HasForeignKey(x => x.SenderBranchId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
                .IsRequired();
            builder.HasOne(x => x.SentBranch)
                .WithMany(x => x.SentStockTransfers)
                .HasForeignKey(x => x.SentBranchId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.StockTransfers)
                .HasForeignKey(x => x.ProductId).IsRequired();

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.StockTransfers)
                .HasForeignKey(x => x.TransactorAppUserId).IsRequired();

            base.Configure(builder);
        }
    }
}
