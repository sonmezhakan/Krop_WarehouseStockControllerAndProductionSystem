using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    /// <summary>
    /// Marka adı en fazla 255 karakter olabilir. Boş olamaz!
    /// Brand nesnesi Owned type özelliğini kullanarak Contact nesnesinin propertylerini kendi bünyesine dahil edilerek tanımlanmıştır.
    /// </summary>
    public class BrandConfiguration:BaseConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.BrandName)
                .HasMaxLength(255)
                .IsRequired();

            #region Contact
            builder.OwnsOne(x => x.Contact, builder =>
            {
                builder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(11);

                builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(128);
            });
            #endregion
            base.Configure(builder);
        }
    }
}
