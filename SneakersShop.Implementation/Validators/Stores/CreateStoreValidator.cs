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
    public class CreateStoreValidator : AbstractValidator<CreateStoreDTO>
    {
        public CreateStoreValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must(x => !context.Stores.Any(s => s.Name == x))
                                .WithMessage("Name is already in use");

            RuleFor(x => x.Address).NotEmpty()
                                   .WithMessage("Address is required")
                                   .Must((store, address) => !context.Stores.Any(y => y.Address == address && y.CityId == store.CityId))
                                   .WithMessage("Address is already in use for this city");

            RuleFor(x => x.Phone).NotEmpty()
                                 .WithMessage("Phone is required")
                                 .Matches("^(06)[0-9]{7,8}$")
                                 .WithMessage("Phone is invalid");

            RuleFor(x => x.CityId).NotEmpty()
                                  .WithMessage("City is required")
                                  .Must(x => context.Cities.Any(y => y.Id == x))
                                  .WithMessage("City does not exist");
        }
    }
}
