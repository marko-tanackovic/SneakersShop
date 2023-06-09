using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfFindOrderQuery : EfUseCase, IFindOrderQuery
    {
        public EfFindOrderQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Find Order";

        public string Description => "Find order with id";

        public OrderDTO Execute(int search)
        {
            var order = Context.Orders.Include(x => x.OrderItems)
                                       .ThenInclude(x => x.Product)
                                         .ThenInclude(x => x.Product)
                                      .Include(x => x.OrderItems)
                                       .ThenInclude(x => x.Product)
                                         .ThenInclude(x => x.Size)
                                     .Include(x => x.Store)
                                     .Include(x => x.User)
                                     .FirstOrDefault(x => x.Id == search && x.IsActive);

            if(order == null)
            {
                throw new EntityNotFoundException(search, nameof(Order));
            }

            return (new OrderDTO
            {
                Id = order.Id,
                Store = order.Store.Name,
                User = order.User.Username,
                OrderDate = order.OrderDate,
                ReceivedDate = order.ReceivedDate,
                Status = order.Status.ToString(),
                OrderItems = order.OrderItems.Select(y => new OrderItemDTO
                {
                    Name = y.Product.Product.Name,
                    Size = y.Product.Size.Number,
                    Price = y.Price,
                    Quantity = y.Quantity
                }),
                Total = order.Total,
                Payment = order.PaymentType.ToString(),
            });
        }
    }
}
