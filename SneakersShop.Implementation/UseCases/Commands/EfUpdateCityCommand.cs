using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
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
    public class EfUpdateCityCommand : EfUseCase, IUpdateCityCommand
    {
        private readonly UpdateCityValidator _validator;
        public EfUpdateCityCommand(SneakersShopContext context,
                                   UpdateCityValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 50;

        public string Name => "Update City";

        public string Description => "Update city by id";

        public void Execute(UpdateCityDTO request)
        {
            var city = Context.Cities.FirstOrDefault(x => x.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (city == null || !city.IsActive || city.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(City));
            }

            if (!string.IsNullOrEmpty(request.ZipCode))
            {
                city.ZipCode = request.ZipCode;
            }

            city.Name = request.Name;
            city.ModifiedAt = DateTime.UtcNow;
            Context.Entry(city).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
