﻿using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krop.DataAccess.Configurations
{
    public class ProductNotificationConfiguration:BaseConfiguration<ProductNotification>
    {
        public override void Configure(EntityTypeBuilder<ProductNotification> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.SenderNotificationDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductNotifications)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.ProductNotifications)
                .HasForeignKey(x => x.BranchId);

            builder.HasOne(x => x.SenderAppUser)
                .WithMany(x => x.SenderProductNotifications)
                .HasForeignKey(x => x.SenderAppUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.SentAppUser)
                .WithMany(x => x.SentProductNotifications)
                .HasForeignKey(x => x.SentAppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
