using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
	/// <summary>
	/// Şube adı en fazla 255 karakter olacak şekilde tanımlanmıştır. Boş olamaz!
	/// Branch nesnesi Owned type özelliğini kullanarak Address ve Contact nesnesinin propertylerini kendi bünyesine dahil edilerek tanımlanmıştır.
	/// </summary>
	public class BranchConfiguration:BaseConfiguration<Branch>
	{
        public override  void Configure(EntityTypeBuilder<Branch> builder)
		{

            builder.Property(x => x.BranchName)
				.HasMaxLength(255)
				.IsRequired();

			#region Contact
			builder.OwnsOne(x => x.Contact,
				builder =>
				{
					builder.Property(c => c.PhoneNumber)
					.HasColumnName("PhoneNumber")
					.HasMaxLength(11);

					builder.Property(e => e.Email)
					.HasColumnName("Email")
					.HasMaxLength(128);
				});
            #endregion

            #region Address
            builder.OwnsOne(x => x.Address,
				builder =>
				{
					builder.Property(a => a.Country)
					.HasColumnName("Country")
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
