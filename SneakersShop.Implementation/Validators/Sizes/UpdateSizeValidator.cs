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
    public class UpdateSizeValidator : AbstractValidator<UpdateSizeDTO>
    {
        public UpdateSizeValidator(SneakersShopContext context)
        {
            When(x => x.Number != null, () =>
            {
                RuleFor(x => x.Number).NotNull()
                                      .WithMessage("Number is required")
                                      .GreaterThan(0)
                                      .WithMessage("Number invalid format");
            });

            RuleFor(x => x.Detail).NotEmpty()
                                  .WithMessage("Detail is required")
                                  .Matches("cm")
                                  .WithMessage("Detail invalid format");
        }
    }
}
