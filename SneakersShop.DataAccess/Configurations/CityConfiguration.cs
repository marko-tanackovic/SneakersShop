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
    public class CityConfiguration : EntityConfiguration<City>
    {
        public override void ConfigureEntity(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(5);
            builder.HasIndex(x => x.ZipCode).IsUnique();

            builder.HasMany(x => x.Users)
                   .WithOne(x => x.City)
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
