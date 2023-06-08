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
    public class SizeConfiguration : EntityConfiguration<Size>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Size> builder)
        {
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Detail).IsRequired();

            builder.HasMany(x => x.SizeProducts)
                   .WithOne(x => x.Size)
                   .HasForeignKey(x => x.SizeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
