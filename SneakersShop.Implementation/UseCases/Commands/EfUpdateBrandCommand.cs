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
    public class EfUpdateBrandCommand : EfUseCase, IUpdateBrandCommand
    {
        private readonly UpdateBrandValidator _validator;
        public EfUpdateBrandCommand(SneakersShopContext context, UpdateBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "Update Brand";

        public string Description => "Update brand name using validator";

        public void Execute(UpdateSizeCategoryColorBrandDTO request)
        {
            var brand = Context.Brands.FirstOrDefault(b => b.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (brand == null || !brand.IsActive || brand.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Brand));
            }

            brand.Name = request.Name;
            brand.ModifiedAt = DateTime.UtcNow;
            Context.Entry(brand).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
