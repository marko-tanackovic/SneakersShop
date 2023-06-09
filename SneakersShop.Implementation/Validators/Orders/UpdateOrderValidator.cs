using FluentValidation;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Validators
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDTO>
    {
        public UpdateOrderValidator(SneakersShopContext context)
        {
            When(x => x.ReceivedDate != null, () =>
            {
                RuleFor(x => x.ReceivedDate).NotNull()
                                            .WithMessage("Received Date is required");
            });

            When(x => x.Status != null, () =>
            {
                RuleFor(x => x.Status).NotEmpty()
                                      .WithMessage("Status is required")
                                      .Must(x => IsInStatus(x))
                                      .WithMessage("Status doesn't exist");
            });
        }

        public bool IsInStatus(string s)
        {
            if (Enum.IsDefined(typeof(OrderStatus), s))
                return true;
            return false;
        }
    }
}
