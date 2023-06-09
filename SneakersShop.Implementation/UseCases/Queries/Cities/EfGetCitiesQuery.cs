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
    public class EfGetCitiesQuery : EfUseCase, IGetCitiesQuery
    {
        public EfGetCitiesQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 46;

        public string Name => "Get Cities";

        public string Description => "Get cities using keyword";

        public IEnumerable<CityDTO> Execute(KeywordSearch search)
        {
            var query = Context.Cities.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword));
            }

            var cities = query.Select(x => new CityDTO
            {
                Id = x.Id,
                Name = x.Name,
                ZipCode = x.ZipCode
            }).ToList();

            return cities;
        }
    }
}
