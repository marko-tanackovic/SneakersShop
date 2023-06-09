using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.UseCases;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using SneakersShop.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfGetOrdersQuery : EfUseCase, IGetOrdersQuery
    {
        public EfGetOrdersQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get Orders";

        public string Description => "";

        public PaginationResponse<OrderDTO> Execute(OrderSearch search)
        {
            var query = Context.Orders.Include(x => x.OrderItems)
                                        .ThenInclude(x => x.Product)
                                           .ThenInclude(x => x.Product)
                                      .Include(x => x.OrderItems)
                                        .ThenInclude(x => x.Product)
                                           .ThenInclude(x => x.Size)
                                      .Include(x => x.Store)
                                      .Include(x => x.User)
                                      .Where(x => x.IsActive && x.DeletedAt == null);

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.ReceivedDate >= search.DateFrom.Value);
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.ReceivedDate <= search.DateTo.Value);
            }
            if (search.PriceFrom.HasValue)
            {
                query = query.Where(x => x.Total >= search.PriceFrom.Value);
            }
            if (search.PriceFrom.HasValue)
            {
                query = query.Where(x => x.Total <= search.PriceTo.Value);
            }
            if (search.Status.HasValue)
            {
                query = query.Where(x => x.Status == search.Status.Value);
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId.Value);
            }

            var result = query.Select(x => new OrderDTO
            {

            }).ToList();

            return query.ToPagedResponse<Order, OrderDTO>(search, x => new OrderDTO
                {
                    Id = x.Id,
                    Store = x.Store.Name,
                    User = x.User.Username,
                    OrderDate = x.OrderDate,
                    ReceivedDate = x.ReceivedDate,
                    Status = x.Status.ToString(),
                    OrderItems = x.OrderItems.Select(y => new OrderItemDTO
                    {
                        Name = y.Product.Product.Name,
                        Size = y.Product.Size.Number,
                        Price = y.Price,
                        Quantity = y.Quantity
                    }),
                    Total = x.Total,
                    Payment = x.PaymentType.ToString()
                }
            );
        }
    }
}
