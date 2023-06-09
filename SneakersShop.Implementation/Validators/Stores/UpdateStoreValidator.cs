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
    public class UpdateStoreValidator : AbstractValidator<UpdateStoreDTO>
    {
        public UpdateStoreValidator(SneakersShopContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required")
                                .Must((store, name) => !context.Stores.Any(x => x.Name == name && x.Id != store.Id && x.IsActive))
                                .WithMessage("Name is already in use");

            When(x => x.CityId != null, () =>
            {
                RuleFor(x => x.CityId).NotEmpty()
                                      .WithMessage("City is required")
                                      .Must(x => context.Cities.Any(y => y.Id == x))
                                      .WithMessage("City doesn't exist");

                RuleFor(x => x.Address).NotEmpty()
                                       .WithMessage("Address is required")
                                       .Must((store, address) => !context.Stores.Any(x => x.Address == address && x.CityId == store.CityId))
                                       .WithMessage("Address is already in use for this city");
            });

            When(x => x.Phone != null, () =>
            {
                RuleFor(x => x.Phone).NotEmpty()
                                     .WithMessage("Phone is required")
                                     .Matches("^(06)[0-9]{7,8}$")
                                     .WithMessage("Phone is invalid");
            });

            When(x => x.Address != null, () =>
            {
                RuleFor(x => x.Address).NotEmpty()
                                       .WithMessage("Address is required");
            });
        }
    }
}
