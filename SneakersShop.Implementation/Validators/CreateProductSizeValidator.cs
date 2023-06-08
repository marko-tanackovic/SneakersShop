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
    public class CreateProductSizeValidator : AbstractValidator<CreateProductSizeDTO>
    {
        public CreateProductSizeValidator(SneakersShopContext context)
        {
            RuleFor(x => x.ProductId).NotNull()
                                     .WithMessage("Product is required")
                                     .Must(x => context.Products.Any(p => p.Id == x))
                                     .WithMessage("Product doesn't exist");

            RuleFor(x => x.SizeId).NotNull()
                                  .WithMessage("Size is required")
                                  .Must(x => context.Sizes.Any(s => s.Id == x))
                                  .WithMessage("Size doesn't exist");

            RuleFor(x => x).Must(x => !context.ProductSizes.Any(ps => ps.ProductId == x.ProductId && ps.SizeId == x.SizeId))
                           .WithMessage("This combination is already in use");

            RuleForEach(x => x.ProductStores).ChildRules(productStore =>
            {
                productStore.RuleFor(x => x.StoreId).NotNull()
                                                    .WithMessage("Store is required")
                                                    .Must(x => context.Stores.Any(s => s.Id == x))
                                                    .WithMessage("Store doesn't exist");

                productStore.RuleFor(x => x.Quantity).NotNull()
                                                     .WithMessage("Quantity is required")
                                                     .GreaterThan(-1)
                                                     .WithMessage("Quantity must be greather than -1");
            });
        }
    }
}
