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
    public class EfUpdateProductSizeStoreCommand : EfUseCase, IUpdateProductSizeStoreCommand
    {
        private readonly UpdateProductSizeStoreValidator _validator;
        public EfUpdateProductSizeStoreCommand(SneakersShopContext context,
                                               UpdateProductSizeStoreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 54;

        public string Name => "Update ProductSizeStore";

        public string Description => "Update ProductSize quantity";

        public void Execute(UpdateProductSizeStoreDTO request)
        {
            var productSize = Context.ProductSizes.FirstOrDefault(x => x.Id == request.Id);

            if (productSize == null || !productSize.IsActive || productSize.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(ProductSize));
            }

            _validator.ValidateAndThrow(request);

            var productSizeStore = Context.StoreProductSizes.FirstOrDefault(x => x.ProductSizeId == productSize.Id && x.StoreId == request.StoreId);

            productSizeStore.Quantity = request.Quantity;
            Context.Entry(productSizeStore).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
