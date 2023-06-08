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
    public class EfUpdateStoreCommand : EfUseCase, IUpdateStoreCommand
    {
        private readonly UpdateStoreValidator _validator;
        public EfUpdateStoreCommand(SneakersShopContext context, UpdateStoreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 35;

        public string Name => "Update Store";

        public string Description => "Update store by id using validators";

        public void Execute(UpdateStoreDTO request)
        {
            var store = Context.Stores.FirstOrDefault(x => x.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (store == null || !store.IsActive || store.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Store));
            }

            if (request.CityId.HasValue)
            {
                store.CityId = request.CityId.Value;
                store.Address = request.Address;
            }

            if (!string.IsNullOrEmpty(request.Phone))
            {
                store.Phone = request.Phone;
            }

            store.Name = request.Name;
            store.ModifiedAt = DateTime.UtcNow;
            Context.Entry(store).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
