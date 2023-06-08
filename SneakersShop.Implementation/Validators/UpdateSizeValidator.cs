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
                                      .Must(x => x > 0)
                                      .WithMessage("Number is not in valid format");

                RuleFor(x => x.Detail).NotEmpty()
                                      .WithMessage("Detail is required")
                                      .Matches("/cm/")
                                      .WithMessage("Detail is not in valid format");
            });

            When(x => x.Detail != null, () =>
            {
                RuleFor(x => x.Detail).NotEmpty()
                                      .WithMessage("Detail is required")
                                      .Matches("/cm/")
                                      .WithMessage("Detail is not in valid format");
            });
        }
    }
}
