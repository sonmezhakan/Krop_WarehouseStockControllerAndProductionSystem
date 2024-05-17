using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
	{
        /// <summary>
        /// Ürün adı en fazla 255 karakter olabilir ve girilmesi zorunludur.
        /// Ürün kodu en fazla 255 karakter olabilir ve girilmesi zorunludur.
        /// Kritik Miktarın default değeri 0 olarak tanımlanmıştır.
        /// Açıklama en fazla 1000 karakter olabilecek şekilde tanımlanmıştır.
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<Product> builder)
		{

            builder.Property(x => x.ProductName)
				.HasMaxLength(255).IsRequired();

			builder.Property(x => x.ProductCode)
				.HasMaxLength(255).IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0.0m).IsRequired();

            builder.Property(x => x.CriticalStock)
				.HasDefaultValue(0).IsRequired();

			builder.Property(x => x.Description)
				.HasMaxLength(1000);

			builder.HasOne(x => x.Category)
				.WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId);

            builder.HasOne(x=>x.Brand)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.BrandId);

            base.Configure(builder);
        }
	}
}
