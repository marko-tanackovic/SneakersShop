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
    public class CreateReviewValidator : AbstractValidator<CreateReviewDTO>
    {
        public CreateReviewValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Text).NotEmpty()
                                .WithMessage("Text is required");

            When(x => x.ParentReviewId != null, () =>
            {
                RuleFor(x => x.ParentReviewId).NotEmpty()
                                              .WithMessage("Parent Review is required")
                                              .Must(x => context.Reviews.Any(r => r.Id == x && r.IsActive))
                                              .WithMessage("Parent Review doesn't exist");
            });

            When(x => x.ParentReviewId == null, () =>
            {
                RuleFor(x => x.Stars).NotEmpty()
                                     .WithMessage("Stars are required")
                                     .Must(x => x >= 0 && x <= 5)
                                     .WithMessage("Stars must be between 0 and 5");

                RuleFor(x => x.ProductId).NotEmpty()
                                         .WithMessage("Product is required")
                                         .Must(x => context.Products.Any(p => p.Id == x))
                                         .WithMessage("Product doesn't exist");
            });
        }
    }
}
