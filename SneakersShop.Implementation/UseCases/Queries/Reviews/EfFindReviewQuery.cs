using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfFindReviewQuery : EfUseCase, IFindReviewQuery
    {
        public EfFindReviewQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Find Review";

        public string Description => "Find review by id";

        public ReviewDTO Execute(int search)
        {
            var review = Context.Reviews.Include(x => x.User)
                                        .Include(x => x.Product)
                                        .Include(x => x.ChildReviews)
                                            .ThenInclude(x => x.ChildReviews)
                                        .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (review == null)
            {
                throw new EntityNotFoundException(search, nameof(Review));
            }

            var print = new ReviewDTO
            {
                Id = review.Id,
                User = review.User.Username,
                Text = review.Text,
                Stars = review.Stars.Value,
                Product = review.Product.Name,
                CommentedAt = review.CreatedAt,
                ChildReviews = review.ChildReviews.Select(y => new ChildReviewDTO
                {
                    Id = y.Id,
                    User = y.User.Username,
                    Text = y.Text,
                    CommentedAt = y.CreatedAt
                })
            };

            foreach (var child in print.ChildReviews)
            {
                handleReviews(child);
            }

            return print;
        }

        private void handleReviews(ChildReviewDTO review)
        {
            var context = new SneakersShopContext();

            var subReviews = context.Reviews.Where(x => x.ParentReviewId == review.Id)
                                            .Select(x => new ChildReviewDTO
                                            {
                                                Id = x.Id,
                                                Text = x.Text,
                                                User = x.User.Username,
                                                CommentedAt = x.CreatedAt
                                            }).ToList();

            review.ChildReviews = subReviews;

            foreach (var sub in subReviews)
            {
                handleReviews(sub);
            }
        }
    }
}
