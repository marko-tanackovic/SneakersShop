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
    public class ProductSizeConfiguration : EntityConfiguration<ProductSize>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasMany(x => x.ProductSizeStores)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductSizeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
