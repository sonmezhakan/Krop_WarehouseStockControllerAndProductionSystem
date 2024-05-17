using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        /// <summary>
        /// Abstract classtaki Id kullanımı engellendi.
        /// AppUserId primary key olarak tanımlandı.
        /// Maaşın veri tabanındaki tipi değerin ondalık kısmının sadece 2 karakter alacak şekilde tanımlandı. Ayrıca default olarak 0 değeri atanmıştır.
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x => x.AppUserId);

            builder.Property(x => x.Salary)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0.0m);

            builder.Property(x => x.WorkingStatu)
                .HasDefaultValue(true);

            builder.HasOne(x => x.AppUser)
                .WithOne(x => x.Employee);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.BranchId);

            base.Configure(builder);
        }
    }
}
