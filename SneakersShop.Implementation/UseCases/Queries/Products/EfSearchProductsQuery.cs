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
    public class EfSearchProductsQuery : ISearchProductsQuery
    {
        public int Id => 1;

        public string Name => "Search Products";

        public string Description => "";

        private readonly SneakersShopContext _context;

        public EfSearchProductsQuery(SneakersShopContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDTO> Execute(ProductSearch search)
        {
            var query = _context.Products.Include(x => x.Brand)
                                         .Include(x => x.Image)
                                         .Include(x => x.Reviews)
                                         .Include(x => x.ProductColors)
                                         .ThenInclude(x => x.Color)
                                         .Include(x => x.ProductSizes)
                                         .ThenInclude(x => x.Size)
                                         .Include(x => x.ProductSizes)
                                         .ThenInclude(x => x.ProductSizeStores)
                                         .ThenInclude(x => x.Store)
                                         .Where(x => x.IsActive && x.DeletedAt == null);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword) ||
                                         x.Code.ToLower().Contains(search.Keyword) ||
                                         x.Brand.Name.ToLower().Contains(search.Keyword));
            }

            if (search.HasReviews.HasValue)
            {
                query = query.Where(x => x.Reviews.Any() == search.HasReviews.Value);
            }

            if (search.BrandId.HasValue)
            {
                query = query.Where(x => x.BrandId == search.BrandId.Value);
            }

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.ReleaseDate >= search.DateFrom.Value);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.ReleaseDate <= search.DateTo.Value);
            }

            if (search.PriceFrom.HasValue)
            {
                query = query.Where(x => x.Price >= search.PriceFrom.Value);
            }

            if (search.PriceTo.HasValue)
            {
                query = query.Where(x => x.Price <= search.PriceTo.Value);
            }

            IEnumerable<ProductDTO> result = query.Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand.Name,
                Code = x.Code,
                ReleaseDate = x.ReleaseDate,
                Colors = x.ProductColors.Select(x => x.Color.Name),
                Image = x.Image.Path,
                Price = x.Discount != 0 ? (x.Price - ((x.Price * (decimal)x.Discount) / 100m)) : x.Price,
                Reviews = x.Reviews.Where(x => x.ParentReview == null).Select(y => new ReviewProductDTO
                {
                    Id = y.Id,
                    Text = y.Text,
                    Stars = y.Stars,
                    User = y.User.Username,
                    CommentedAt = y.CreatedAt,
                }),
                Sizes = x.ProductSizes.Select(z => new ProductSizeDTO
                {
                    Size = z.Size.Number,
                    StoreSizes = z.ProductSizeStores.Select(p => new StoreSizeDTO
                    {
                        Store = p.Store.Name,
                        Quantity = p.Quantity
                    })
                })
            }).ToList();

            foreach (var res in result)
            {
                foreach (var review in res.Reviews)
                {
                    handleReviews(review);
                }
            }

            return result;
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
