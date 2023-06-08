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
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDTO>
    {
        public UpdateReviewValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Text).NotEmpty()
                                .WithMessage("Text is required");

            When(x => x.Stars != null, () =>
            {
                RuleFor(x => x.Stars).NotEmpty()
                                     .WithMessage("Stars are required")
                                     .Must(x => x >= 0 && x <= 5)
                                     .WithMessage("Stars must be between 0 and 5");
            });
        }
    }
}
