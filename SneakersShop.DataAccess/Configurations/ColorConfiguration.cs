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
    public class ColorConfiguration : EntityConfiguration<Color>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Color> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.ColorProducts)
                   .WithOne(x => x.Color)
                   .HasForeignKey(x => x.ColorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
