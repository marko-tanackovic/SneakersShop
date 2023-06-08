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
    public class EfGetBrandsQuery : IGetBrandsQuery
    {
        public int Id => 3;

        public string Name => "Get Brands";

        public string Description => "";

        private readonly SneakersShopContext _context;

        public EfGetBrandsQuery(SneakersShopContext context)
        {
            _context = context;
        }

        public IEnumerable<BrandColorDTO> Execute(KeywordSearch search)
        {
            var query = _context.Brands.Include(x => x.Products).AsQueryable().Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword));
            }

            return(query.Select(x => new BrandColorDTO
            {
                Id = x.Id,
                Name = x.Name,
                Products = x.Products.Count()
            }));
        }
    }
}
