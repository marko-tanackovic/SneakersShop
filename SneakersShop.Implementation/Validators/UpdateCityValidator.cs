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
    public class UpdateCityValidator : AbstractValidator<UpdateCityDTO>
    {
        public UpdateCityValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must((color, name) => !context.Cities.Any(c => c.Name == name && c.Id != color.Id && c.IsActive))
                                .WithMessage("Name is already in use");

            RuleFor(x => x.ZipCode).NotEmpty()
                                .WithMessage("Name is required")
                                .Must((city, name) => !context.Cities.Any(c => c.Name == name && c.Id != city.Id && c.IsActive))
                                .When(x => x.ZipCode is not null)
                                .WithMessage("Name is already in use");
        }
    }
}
