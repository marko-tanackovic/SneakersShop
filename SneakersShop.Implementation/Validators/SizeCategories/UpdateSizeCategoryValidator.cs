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
    public class UpdateSizeCategoryValidator : AbstractValidator<UpdateSizeCategoryColorBrandDTO>
    {
        public UpdateSizeCategoryValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must((scategory, name) => !context.SizeCategories.Any(sc => sc.Name == name && sc.Id != scategory.Id && sc.IsActive))
                                .WithMessage("Name is already in use");
        }
    }
}
