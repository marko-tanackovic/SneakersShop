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
    public class EfGetSizesQuery : EfUseCase, IGetSizesQuery
    {
        public EfGetSizesQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Get Sizes";

        public string Description => "";

        public IEnumerable<SizeDTO> Execute(SizeSearch search)
        {
            var query = Context.Sizes.Include(x => x.SizeCategory)
                                     .Where(x => x.IsActive);

            if (search.SizeFrom.HasValue)
            {
                query = query.Where(x => x.Number >= search.SizeFrom.Value);
            }
            if (search.SizeTo.HasValue)
            {
                query = query.Where(x => x.Number <= search.SizeTo.Value);
            }

            var result = query.Select(x => new SizeDTO
            {
                Id = x.Id,
                Number = x.Number,
                Detail = x.Detail,
                SizeCategory = x.SizeCategory.Name
            }).ToList();

            return result;
        }
    }
}
