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
    public class EfGetColorsQuery : EfUseCase, IGetColorsQuery
    {
        public EfGetColorsQuery(SneakersShopContext context) : base(context)
        {
            
        }

        public int Id => 7;

        public string Name => "Get Colors";

        public string Description => "";

        public IEnumerable<BrandColorDTO> Execute(KeywordSearch search)
        {
            var query = Context.Colors.Include(x => x.ColorProducts)
                                      .ThenInclude(x => x.Product)
                                      .AsQueryable().Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword));
            }

            var colors = query.Select(x => new BrandColorDTO
            {
                Id = x.Id,
                Name = x.Name,
                Products = x.ColorProducts.Count
            }).ToList();

            return colors;
        }
    }
}
