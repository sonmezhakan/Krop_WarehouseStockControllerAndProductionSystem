using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class StockConfiguration : BaseConfiguration<Stock>
    {

        /// <summary>
        /// Abstract classtan gelen id kullanıma kapatılmıştır.
        /// BranchId ve ProductId Composite Key olarak tanımlanmıştır.
        /// Stok miktarının default değeri 0 olarak tanımlanmıştır.
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x => new { x.BranchId, x.ProductId });

            builder.Property(x => x.UnitsInStock)
                .HasDefaultValue(0).IsRequired();

            builder.HasOne(b => b.Branch)
                .WithMany(s => s.Stocks)
                .HasForeignKey(s => s.BranchId);

            builder.HasOne(p => p.Product)
                .WithMany(s => s.Stocks)
                .HasForeignKey(s => s.ProductId);

            base.Configure(builder);
        }
    }
}
