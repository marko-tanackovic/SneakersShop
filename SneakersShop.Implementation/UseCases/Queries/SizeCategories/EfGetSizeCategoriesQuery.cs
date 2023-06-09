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
    public class EfGetSizeCategoriesQuery : EfUseCase, IGetSizeCategoriesQuery
    {
        public EfGetSizeCategoriesQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Get Size Categories";

        public string Description => "";

        public IEnumerable<SizeCategoryDTO> Execute(KeywordSearch search)
        {
            var query = Context.SizeCategories.Include(x => x.Sizes)
                                              .Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword));
            }

            var result = query.Select(x => new SizeCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                Sizes = x.Sizes.OrderBy(x => x.Number).Select(y => y.Number)
            }).ToList();

            return result;
        }
    }
}
