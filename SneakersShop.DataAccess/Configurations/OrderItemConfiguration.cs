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
    public class OrderItemConfiguration : EntityConfiguration<OrderItem>
    {
        public override void ConfigureEntity(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.OrderItems)
                   .HasForeignKey(x => x.ProductSizeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
