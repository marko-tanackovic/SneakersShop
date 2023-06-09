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
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0);

            builder.HasMany(x => x.ProductSizes)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ProductColors)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Reviews)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
