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
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator(SneakersShopContext context, IBase64FileUploader uploader)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .MaximumLength(100)
                                .WithMessage("Name must have lower than 100 characters")
                                .Must(x => !context.Products.Any(p => p.Name == x && p.IsActive))
                                .WithMessage("Name is already in use");

            RuleFor(x => x.BrandId).NotNull()
                                   .WithMessage("Brand is required")
                                   .Must(x => context.Brands.Any(b => b.Id == x && b.IsActive))
                                   .WithMessage("Brand doesn't exist");

            RuleFor(x => x.Code).NotEmpty()
                                .WithMessage("Code is required")
                                .MaximumLength(100)
                                .WithMessage("Code must have lower than 100 characters")
                                .Must(x => !context.Products.Any(p => p.Code == x && p.IsActive))
                                .WithMessage("Code is already in use");

            RuleFor(x => x.Price).NotEmpty()
                                 .WithMessage("Price is required")
                                 .Must(x => x > 0)
                                 .WithMessage("Price must be higher than 0");

            RuleFor(x => x.Colors).NotNull()
                                  .WithMessage("Colors are required");

            RuleFor(x => x.Image).NotNull()
                                 .WithMessage("Image is required")
                                 .Must(x => uploader.IsExtensionValid(x) &&
                                                       new List<string> { "jpg", "png" }.Contains(uploader.GetExtension(x)))
                                 .WithMessage("Invalid file extesion. Allowed are .jpg, .png and .jpeg");
        }
    }
}
