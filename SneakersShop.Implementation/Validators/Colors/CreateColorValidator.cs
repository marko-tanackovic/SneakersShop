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
    public class CreateColorValidator : AbstractValidator<CreateSizeCategoryBrandColorDTO>
    {
        public CreateColorValidator(SneakersShopContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must(x => !context.Colors.Any(c => c.Name == x && c.IsActive))
                                .WithMessage("Name is already in use");
        }
    }
}
