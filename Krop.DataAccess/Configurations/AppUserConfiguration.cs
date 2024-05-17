using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
	public class AppUserConfiguration : BaseConfiguration<AppUser>
	{

        /// <summary>
        /// AppUser nesnesinde Owned Entity özelliği kullanıldığından ötürü Person ve Person.Address nesnelerinin propertylerini veri tabanında AppUser tablosunda görüntülenmesi için tanımlanmıştır.
        /// Ayrıca bu özellik kullanıldığında diğer nesnelerin propertyleri veritabanına eklenirken kolon isimleri önce tablo adı daha sonrasında property adı yazılarak belirtiliyor. Bu durumun önüne geçmek için kolon isimleride aşağıda tekrardan tanımlanmıştır.
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<AppUser> builder)
		{

			#region Person
			builder.OwnsOne(p => p.Person,
				builder =>
				{
					builder.Property(p => p.FirstName)
					.HasColumnName("FirstName")
					.HasMaxLength(128)
					.IsRequired();

					builder.Property(p => p.LastName)
					.HasColumnName("LastName")
					.HasMaxLength(128)
					.IsRequired();

					builder.Property(p => p.NationalNumber)
					.HasColumnName("NationalNumber")
					.HasMaxLength(11);
				});
			#endregion
			#region Address
			builder.OwnsOne(a => a.Address,
				builder =>
				{
					builder.Property(a => a.Country)
					.HasColumnName("Contry")
					.HasMaxLength(64);

					builder.Property(a => a.City)
					.HasColumnName("City")
					.HasMaxLength(64);

					builder.Property(a => a.Addres)
					.HasColumnName("Addres")
					.HasMaxLength(255);
				});
            #endregion
            base.Configure(builder);
        }
	}
}
