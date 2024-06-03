using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class ProductionConfiguration:BaseConfiguration<Production>
    {
        public override void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x=>x.BranchId).IsRequired();
            builder.Property(x=>x.AppUserId).IsRequired();

            builder.Property(x => x.ProductionQuantity).IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Productions)
                .HasForeignKey(x => x.BranchId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Productions)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Productions)
                .HasForeignKey(x => x.AppUserId);
            base.Configure(builder);
        }
    }
}
