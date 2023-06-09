using FluentValidation;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Validators
{
    public class UpdateProductSizeStoreValidator : AbstractValidator<UpdateProductSizeStoreDTO>
    {
        public UpdateProductSizeStoreValidator(SneakersShopContext context)
        {
            RuleFor(x => x.StoreId).NotNull()
                                   .WithMessage("Store is required")
                                   .Must(x => context.Stores.Any(s => s.Id == x))
                                   .WithMessage("Store doesn't exist");

            RuleFor(x => x.Quantity).NotNull()
                                    .WithMessage("Quantity is required")
                                    .GreaterThan(-1)
                                    .WithMessage("Quantity must be greather than -1");
        }
    }
}
