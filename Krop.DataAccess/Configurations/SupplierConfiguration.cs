using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class SupplierConfiguration : BaseConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.WebSite)
                .HasMaxLength(255);

            #region Company
            builder.OwnsOne(x => x.Company,
                company =>
            {
                company.Property(c => c.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("CompanyName")
                .IsRequired();

                company.Property(c => c.ContactName)
                .HasMaxLength(255)
                .HasColumnName("ContactName");

                company.Property(c => c.ContactTitle)
                .HasMaxLength(64)
                .HasColumnName("ContactTitle");
            });
            #endregion
            #region Contact

            builder.OwnsOne(x => x.Contact,
                contact =>
                {
                    contact.Property(c => c.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(11);

                    contact.Property(x => x.Email)
                    .HasColumnName("Email");
                });
            #endregion
            #region Address
            builder.OwnsOne(x => x.Address, address=>
            {
                address.Property(a => a.Country)
                .HasMaxLength(64)
                .HasColumnName("Country");

                address.Property(a => a.City)
                .HasMaxLength(64)
                .HasColumnName("City");

                address.Property(a => a.Addres)
                .HasMaxLength(255)
                .HasColumnName("Addres");
            });
                
            #endregion

            base.Configure(builder);
        }
    }
}
