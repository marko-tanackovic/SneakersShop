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
    public class UpdateBrandValidator : AbstractValidator<UpdateSizeCategoryColorBrandDTO>
    {
        public UpdateBrandValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must((brand, name) => !context.Brands.Any(b => b.Name == name && b.Id != brand.Id && b.IsActive))
                                .WithMessage("Name is already in use");
        }
    }
}
