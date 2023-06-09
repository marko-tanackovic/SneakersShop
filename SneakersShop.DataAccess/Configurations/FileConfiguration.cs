using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.DataAccess.Configurations
{
    public class FileConfiguration : EntityConfiguration<File>
    {
        public override void ConfigureEntity(EntityTypeBuilder<File> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(250);
        }
    }
}
