using FluentValidation;
using SneakersShop.Application.Uploads;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator(SneakersShopContext context, IBase64FileUploader uploader)
        {
            When(x => x.Name != null, () =>
            {
                RuleFor(x => x.Name).NotEmpty()
                                    .WithMessage("Name is required")
                                    .Must((product, name) => !context.Products.Any(x => x.Name == name && x.Id != product.Id && x.IsActive))
                                    .WithMessage("Name is already in use");
            });

            When(x => x.Code != null, () =>
            {
                RuleFor(x => x.Code).NotEmpty()
                                    .WithMessage("Code is required")
                                    .Must((product, code) => !context.Products.Any(x => x.Code == code && x.Id != product.Id && x.IsActive))
                                    .WithMessage("Code is already in use");
            });

            When(x => x.Price != null, () =>
            {
                RuleFor(x => x.Price).NotNull()
                                     .WithMessage("Price is required")
                                     .Must(x => x > 0)
                                     .WithMessage("Price must be higher than 0");
            });

            When(x => x.Discount != null, () =>
            {
                RuleFor(x => x.Discount).NotNull()
                                        .WithMessage("Discount is required")
                                        .Must(x => x < 100)
                                        .WithMessage("Discount can't be 100");
            });

            When(x => x.BrandId != null, () =>
            {
                RuleFor(x => x.BrandId).NotNull()
                                       .WithMessage("Brand is required")
                                       .Must(x => context.Brands.Any(b => b.Id == x && b.IsActive))
                                       .WithMessage("Brand doesn't exist");
            });

            When(x => x.Image != null, () =>
            {
                RuleFor(x => x.Image).NotNull()
                                     .WithMessage("Image is required")
                                     .Must(x => uploader.IsExtensionValid(x) &&
                                                       new List<string> { "jpg", "png" }.Contains(uploader.GetExtension(x)))
                                     .WithMessage("Invalid file extesion. Allowed are .jpg, .png and .jpeg");
            });

            When(x => x.Colors != null, () =>
            {
                RuleFor(x => x.Colors).NotNull()
                                      .WithMessage("Colors are required");
            });
        }
    }
}
