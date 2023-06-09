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
    public class EfFindStoreQuery : EfUseCase, IFindStoreQuery
    {
        public EfFindStoreQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Find Store";

        public string Description => "";

        public StoreDTO Execute(int search)
        {
            var store = Context.Stores.Include(x => x.StoreProducts)
                                        .ThenInclude(x => x.Product)
                                            .ThenInclude(x => x.Product)
                                        .Include(x => x.StoreProducts)
                                            .ThenInclude(x => x.Product)
                                                .ThenInclude(x => x.Size)
                                        .Include(x => x.City)
                                                .FirstOrDefault(x => x.Id == search && x.IsActive);

            if(store == null)
            {
                throw new EntityNotFoundException(search, nameof(Store));
            }

            var result = new StoreDTO {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
                City = store.City.Name,
                Phone = store.Phone,
                ZipCode = store.City.ZipCode,
                StoreProducts = store.StoreProducts.Select(y => new StoreProductDTO
                {
                    Name = y.Product.Product.Name,
                    Size = y.Product.Size.Number,
                    Quantity = y.Quantity
                })
            };

            return result;
        }
    }
}
