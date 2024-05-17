using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class DepartmentConfiguration:BaseConfiguration<Department>
	{
        /// <summary>
        /// Departman Adı en fazla 255 karakter olabilecek şekilde tanımlanmıştır. Boş olamaz!
        /// Açıklama en fazla 255 karakter olabilecek şekilde tanımlanmıştıor. Boş olabilir!
        /// </summary>
        /// <param name="builder"></param>
        public override  void Configure(EntityTypeBuilder<Department> builder)
		{
            
            builder.Property(x => x.DepartmentName)
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.Description)
				.HasMaxLength(255);

            base.Configure(builder);
        }
	}
}
