using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class ProductReceiptConfiguration:BaseConfiguration<ProductReceipt>
    {
        public override void Configure(EntityTypeBuilder<ProductReceipt> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x=> new {x.ProduceProductId, x.ProductId});

            builder.Property(x=>x.Quantity).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductReceipts).HasForeignKey(x => x.ProduceProductId);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductReceipts).HasForeignKey(x => x.ProductId);
            
            base.Configure(builder);
        }
    }
}
