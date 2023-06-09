using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfDeleteReviewCommand : EfUseCase, IDeleteReviewCommand
    {
        public EfDeleteReviewCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 38;

        public string Name => "Delete Review";

        public string Description => "Delete review by id";

        public void Execute(int request)
        {
            var review = Context.Reviews.FirstOrDefault(r => r.Id == request);

            if (review == null || !review.IsActive || review.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Review));
            }

            review.DeletedAt = DateTime.UtcNow;
            review.IsActive = false;

            Context.SaveChanges();
        }
    }
}
