using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfDeleteCityCommand : EfUseCase, IDeleteCityCommand
    {
        public EfDeleteCityCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 48;

        public string Name => "Delete City";

        public string Description => "Delete city by id";

        public void Execute(int request)
        {
            var city = Context.Cities.FirstOrDefault(c => c.Id == request);

            if (city == null || !city.IsActive || city.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(City));
            }

            city.DeletedAt = DateTime.UtcNow;
            city.IsActive = false;

            Context.SaveChanges();
        }
    }
}
