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
    public class EfGetStoresQuery : EfUseCase, IGetStoresQuery
    {
        public EfGetStoresQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Get Stores";

        public string Description => throw new NotImplementedException();

        public IEnumerable<StoreDTO> Execute(KeywordSearch search)
        {
            var query = Context.Stores.Include(x => x.StoreProducts)
                                        .ThenInclude(x => x.Product)
                                            .ThenInclude(x => x.Product)
                                      .Include(x => x.City)
                                                .Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword) ||
                                         x.Address.ToLower().Contains(search.Keyword) ||
                                         x.City.Name.ToLower().Contains(search.Keyword));
            }

            var stores = query.Select(x => new StoreDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City.Name,
                Phone = x.Phone,
                ZipCode = x.City.ZipCode,
                StoreProducts = x.StoreProducts.Select(y => new StoreProductDTO
                {
                    Name = y.Product.Product.Name,
                    Size = y.Product.Size.Number,
                    Quantity = y.Quantity
                })
            }).ToList();

             return stores;
        }
    }
}
