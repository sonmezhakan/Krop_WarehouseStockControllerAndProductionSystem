using Krop.Entities.Enums;
using Krop.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class,IEntity<Guid>
	{
        /// <summary>
        /// Base Konfigürasyon işlemleri burada tanımlanmıştır.
        /// CreatedDate,CreadtedComputerName,CreatedIpAddress / UpdatedDate,UpdatedComputerName,UpdatedIpAddress / DeletedDate,DaletedComputerName, DeletedIpAddress ve DataStatu Shadow Propertylerinin tanımlanması yapılmıştır.
        /// Shadow propertyi veritabanında verilerle ilgili her sorgulama yapıldığında bu bilgilerin gelmesini engelleyerek gereksiz yere veri getirmekten kurtulmuş oluyoruz. Bu sayede ram de yer kaplamamış oluyor.
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			//Shadow Property üzerinde global bir filtre oluşturarak herhangi bir veri sorgulama aşamasında DataStatu'su Deleted olmayanları geri döndürecek sorgu.
			builder.HasQueryFilter(e => EF.Property<DataStatu>(e,"DataStatu") != DataStatu.Deleted);

			#region Shadow Property
			builder.Property<DateTime?>("CreatedDate");
			builder.Property<string?>("CreatedComputerName");
			builder.Property<string?>("CreatedIpAddress");

			builder.Property<DateTime?>("UpdatedDate");
			builder.Property<string?>("UpdatedComputerName");
			builder.Property<string?>("UpdatedIpAddress");

			builder.Property<DateTime?>("DeletedDate");
			builder.Property<string?>("DeletedComputerName");
			builder.Property<string?>("DeletedIpAddress");

			builder.Property<DataStatu>("DataStatu");
			#endregion
		}
	}
}
