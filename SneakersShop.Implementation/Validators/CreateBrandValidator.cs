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
    public class CreateBrandValidator : AbstractValidator<CreateSizeCategoryBrandColorDTO>
    {
        public CreateBrandValidator(SneakersShopContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must(x => !context.Brands.Any(b => b.Name == x && b.IsActive))
                                .WithMessage("Name is already in use");
        }
    }
}
