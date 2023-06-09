using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using SneakersShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfUpdateOrderCommand : EfUseCase, IUpdateOrderCommand
    {
        private readonly UpdateOrderValidator _validator;
        public EfUpdateOrderCommand(SneakersShopContext context, UpdateOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Update Order";

        public string Description => "Update order by id using validator";

        public void Execute(UpdateOrderDTO request)
        {
            var order = Context.Orders.FirstOrDefault(x => x.Id == request.Id);

            if (order == null || !order.IsActive || order.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Order));
            }

            _validator.ValidateAndThrow(request);

            if (request.ReceivedDate.HasValue)
            {
                order.ReceivedDate = request.ReceivedDate.Value;
                order.Status = OrderStatus.Completed;
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                Enum.TryParse(request.Status, out OrderStatus status);
                order.Status = status;
            }

            order.ModifiedAt = DateTime.UtcNow;
            Context.Entry(order).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
