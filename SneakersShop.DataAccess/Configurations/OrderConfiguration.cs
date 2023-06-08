using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.DataAccess.Configurations
{
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.PromisedDate).IsRequired();
            builder.Property(x => x.ReceivedDate).HasDefaultValue(null);
            builder.Property(x => x.Total).IsRequired();

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
