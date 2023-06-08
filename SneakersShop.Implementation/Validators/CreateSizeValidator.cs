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
    public class CreateSizeValidator : AbstractValidator<CreateSizeDTO>
    {
        public CreateSizeValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Number).NotEmpty()
                                  .WithMessage("Number is required")
                                  .Must((size, number) => !context.Sizes.Any(s => s.SizeCategoryId == size.SizeCategoryId && s.Number == number))
                                  .WithMessage("Number is already in use for this category");

            RuleFor(x => x.Detail).NotEmpty()
                                  .WithMessage("Detail is required");

            RuleFor(x => x.SizeCategoryId).NotNull()
                                          .WithMessage("Size Category is required")
                                          .Must(x => !context.SizeCategories.Any(s => s.Id == x && s.IsActive))
                                          .WithMessage("Size Category doesn't exist");
        }
    }
}
