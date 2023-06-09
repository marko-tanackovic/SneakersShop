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
    public class EfCreateStoreCommand : EfUseCase, ICreateStoreCommand
    {
        private readonly CreateStoreValidator _validator;
        public EfCreateStoreCommand(SneakersShopContext context, CreateStoreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Create Store";

        public string Description => "";

        public void Execute(CreateStoreDTO request)
        {
            _validator.ValidateAndThrow(request);



            var newStore = new Store
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                CityId = request.CityId
            };

            Context.Stores.Add(newStore);

            Context.SaveChanges();
        }
    }
}
