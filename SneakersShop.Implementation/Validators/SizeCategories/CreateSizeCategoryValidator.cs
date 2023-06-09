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
    public class CreateSizeCategoryValidator : AbstractValidator<CreateSizeCategoryBrandColorDTO>
    {
        public CreateSizeCategoryValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must(x => !context.SizeCategories.Any(y => y.Name == x))
                                .WithMessage("Name is already in use");
        }
    }
}
