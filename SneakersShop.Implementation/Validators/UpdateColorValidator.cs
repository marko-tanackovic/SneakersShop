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
    public class UpdateColorValidator : AbstractValidator<UpdateSizeCategoryColorBrandDTO>
    {
        public UpdateColorValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must((color, name) => !context.Colors.Any(c => c.Name == name && c.Id != color.Id && c.IsActive))
                                .WithMessage("Name is already in use");
        }
    }
}
