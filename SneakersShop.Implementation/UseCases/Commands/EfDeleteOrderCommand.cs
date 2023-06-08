using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfDeleteOrderCommand : EfUseCase, IDeleteOrderCommand
    {
        public EfDeleteOrderCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Delete Order";

        public string Description => "";

        public void Execute(int request)
        {
            var order = Context.Orders.Include(x => x.OrderItems)
                                      .FirstOrDefault(o => o.Id == request);

            if (order == null || !order.IsActive || order.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Order));
            }

            foreach(var item in order.OrderItems)
            {
                item.DeletedAt = DateTime.UtcNow;
                item.IsActive = false;
            }

            order.DeletedAt = DateTime.UtcNow;
            order.IsActive = false;

            Context.SaveChanges();
        }
    }
}
