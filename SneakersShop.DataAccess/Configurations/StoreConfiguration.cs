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
    public class StoreConfiguration : EntityConfiguration<Store>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Store> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);

            builder.HasMany(x => x.StoreProducts)
                   .WithOne(x => x.Store)
                   .HasForeignKey(x => x.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
