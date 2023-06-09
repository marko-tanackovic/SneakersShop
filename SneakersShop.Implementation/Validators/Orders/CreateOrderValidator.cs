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
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator(SneakersShopContext context)
        {
            RuleFor(x => x.StoreId).NotNull()
                                   .WithMessage("Store is required")
                                   .Must(x => context.Stores.Any(s => s.Id == x))
                                   .WithMessage("Store doesn't exist");

            RuleFor(x => x.UserId).NotNull()
                                  .WithMessage("User is required")
                                  .Must(x => context.Users.Any(u => u.Id == x))
                                  .WithMessage("User doesn't exist");

            RuleFor(x => x.OrderDate).NotNull()
                                     .WithMessage("Order Date is required");

            RuleFor(x => x.PromisedDate).NotNull()
                                        .WithMessage("Promised Date is required")
                                        .Must((order,date) => order.OrderDate < date)
                                        .WithMessage("Promised Date is invalid");

            RuleFor(x => x.Payment).NotNull()
                                   .WithMessage("Payment is required")
                                   .Must(x => IsInPaymentType(x))
                                   .WithMessage("Payment type doesn't exist");

            RuleFor(x => x.OrderItems).NotNull()
                                      .WithMessage("Order items are required");
        }

        public bool IsInPaymentType(string s)
        {
            if (Enum.IsDefined(typeof(PaymentType), s))
                return true;
            return false;
        }
    }
}
