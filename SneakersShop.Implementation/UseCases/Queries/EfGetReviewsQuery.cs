using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfGetReviewsQuery : EfUseCase, IGetReviewsQuery
    {
        public EfGetReviewsQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Get Reviews";

        public string Description => "Get reviews using search parameters";

        public IEnumerable<ReviewDTO> Execute(ReviewSearch search)
        {
            var query = Context.Reviews.Include(x => x.User)
                                       .Include(x => x.Product)
                                       .Include(x => x.ChildReviews)
                                        .ThenInclude(x => x.ChildReviews)
                                       .Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();

                query = query.Where(x => x.Text.ToLower().Contains(search.Keyword) ||
                                         x.User.Username.ToLower().Contains(search.Keyword));
            }

            if (search.HasChildren.HasValue)
            {
                query = query.Where(x => x.ChildReviews.Any() == search.HasChildren.Value);
            }

            if (search.ProductId.HasValue)
            {
                query = query.Where(x => x.ProductId == search.ProductId.Value);
            }

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId.Value);
            }

            var result = query.Where(x => x.ParentReviewId == null).Select(x => new ReviewDTO
            {
                Id = x.Id,
                User = x.User.Username,
                Text = x.Text,
                Stars = x.Stars.Value,
                Product = x.Product.Name,
                CommentedAt = x.CreatedAt,
                ChildReviews = x.ChildReviews.Select(y => new ChildReviewDTO
                {
                    Id = y.Id,
                    User = y.User.Username,
                    Text = y.Text,
                    CommentedAt = y.CreatedAt
                })
            }).ToList();

            foreach (var res in result)
            {
                foreach (var review in res.ChildReviews)
                {
                    handleReviews(review);
                }
            }

            return result;
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
