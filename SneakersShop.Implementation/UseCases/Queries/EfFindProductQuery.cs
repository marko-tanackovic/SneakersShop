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
    public class EfFindProductQuery : IFindProductQuery
    {
        public int Id => 4;

        public string Name => "Find Product";

        public string Description => "";

        private readonly SneakersShopContext _context;

        public EfFindProductQuery(SneakersShopContext context)
        {
            _context = context;
        }

        public ProductDTO Execute(int search)
        {
            var product = _context.Products.Include(x => x.Reviews)
                                           .Include(x => x.Image)
                                           .Include(x => x.Brand)
                                           .Include(x => x.ProductColors)
                                             .ThenInclude(x => x.Color)
                                           .Include(x => x.ProductSizes)
                                             .ThenInclude(x => x.Size)
                                           .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (product == null)
            {
                throw new EntityNotFoundException(search, nameof(Product));
            }

            var print = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand.Name,
                Code = product.Code,
                ReleaseDate = product.ReleaseDate,
                Colors = product.ProductColors.Select(x => x.Color.Name),
                Image = product.Image.Path,
                Price = product.Discount != 0 ? (product.Price - ((product.Price * (decimal)product.Discount) / 100m)) : product.Price,
                Reviews = product.Reviews.Select(x => new ReviewProductDTO
                {
                    Id = x.Id,
                    Text = x.Text,
                    Stars = x.Stars,
                    User = x.User.Username,
                    CommentedAt = x.CreatedAt,
                }),
                Sizes = product.ProductSizes.Select(x => x.Size.Number)
            };

            foreach (var review in print.Reviews)
            {
                handleReviews(review);
            }

            return print;
        }

        private void handleReviews(ReviewProductDTO review)
        {
            var context = new SneakersShopContext();

            var subReviews = context.Reviews.Where(x => x.ParentReviewId == review.Id)
                                            .Select(x => new ReviewProductDTO
                                            {
                                                Id = x.Id,
                                                Text = x.Text,
                                                Stars = x.Stars,
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
