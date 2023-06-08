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
    public class EfFindCityQuery : EfUseCase, IFindCityQuery
    {
        public EfFindCityQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 47;

        public string Name => "Find City";

        public string Description => "Find city by id";

        public CityDTO Execute(int search)
        {
            var city = Context.Cities.FirstOrDefault(x => x.Id == search && x.IsActive);

            if (city == null)
            {
                throw new EntityNotFoundException(search, nameof(City));
            }

            return (new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                ZipCode = city.ZipCode
            });
        }
    }
}
