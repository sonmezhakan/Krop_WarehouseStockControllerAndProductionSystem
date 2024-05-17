using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
	public class CategoryConfiguration:BaseConfiguration<Category>
	{
        /// <summary>
        /// Kategori adı en fazla 64 karakter olabilir ve girilmesi zorunlu olarak tanımlanmıştır.
        /// </summary>
        /// <param name="builder"></param>
        public override  void Configure(EntityTypeBuilder<Category> builder)
		{

            builder.Property(x => x.CategoryName)
				.HasMaxLength(64)
				.IsRequired();

			builder.HasMany(x => x.Products)
				.WithOne(x => x.Category);

            base.Configure(builder);
        }
	}
}
