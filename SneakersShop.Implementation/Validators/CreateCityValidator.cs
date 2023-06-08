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
    public class CreateCityValidator : AbstractValidator<CreateCityDTO>
    {
        public CreateCityValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must(x => !context.Cities.Any(c => c.Name == x))
                                .WithMessage("Name is already in use");

            RuleFor(x => x.ZipCode).NotEmpty()
                                   .WithMessage("ZipCode is required")
                                   .Must(x => !context.Cities.Any(c => c.ZipCode == x))
                                   .WithMessage("ZipCode is already in use");
        }
    }
}
