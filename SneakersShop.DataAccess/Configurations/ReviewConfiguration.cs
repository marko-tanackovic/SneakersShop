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
    public class ReviewConfiguration : EntityConfiguration<Review>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.ChildReviews)
                   .WithOne(x => x.ParentReview)
                   .HasForeignKey(x => x.ParentReviewId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
