using FluentValidation;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using SneakersShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfCreateCityCommand : EfUseCase, ICreateCityCommand
    {
        private readonly CreateCityValidator _validator;
        public EfCreateCityCommand(SneakersShopContext context,
                                   CreateCityValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 49;

        public string Name => "Create City";

        public string Description => "Create city with validators";

        public void Execute(CreateCityDTO request)
        {
            _validator.ValidateAndThrow(request);

            var newCity = new City
            {
                Name = request.Name,
                ZipCode = request.ZipCode
            };

            Context.Cities.Add(newCity);

            Context.SaveChanges();
        }
    }
}
