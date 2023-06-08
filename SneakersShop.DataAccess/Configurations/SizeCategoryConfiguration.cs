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
    public class SizeCategoryConfiguration : EntityConfiguration<SizeCategory>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SizeCategory> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.Sizes)
                   .WithOne(x => x.SizeCategory)
                   .HasForeignKey(x => x.SizeCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
