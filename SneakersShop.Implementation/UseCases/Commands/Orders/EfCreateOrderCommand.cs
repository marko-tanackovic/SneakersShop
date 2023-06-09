using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using SneakersShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfCreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private readonly CreateOrderValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateOrderCommand(SneakersShopContext context, 
                                    CreateOrderValidator validator,
                                    IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 33;

        public string Name => "Create Order";

        public string Description => "Create order using validator";

        public void Execute(CreateOrderDTO request)
        {
            _validator.ValidateAndThrow(request);

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in request.OrderItems)
            {
                var findItem = Context.ProductSizes.Include(x => x.Product)
                                                   .Include(x => x.ProductSizeStores)
                                                   .FirstOrDefault(x => x.Id == item.ProductId && x.IsActive);

                if (findItem == null)
                {
                    throw new EntityNotFoundException(item.ProductId, nameof(ProductSize));
                }

                var newOrderItem = new OrderItem
                {
                    ProductSizeId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = findItem.Product.Price
                };

                var store = Context.Stores.Find(request.StoreId);

                var findStoreProduct = Context.StoreProductSizes.FirstOrDefault(x => x.StoreId == request.StoreId && x.ProductSizeId == item.ProductId);

                findStoreProduct.Quantity = findStoreProduct.Quantity - item.Quantity;
                Context.Entry(findStoreProduct).State = EntityState.Modified;

                if (findStoreProduct.Quantity < 0)
                {
                    throw new NotInStockException(item.ProductId, store.Name);
                }

                orderItems.Add(newOrderItem);
            }

            Enum.TryParse(request.Payment, out PaymentType type);

            var newOrder = new Order
            {
                StoreId = request.StoreId,
                UserId = _actor.Id,
                OrderDate = request.OrderDate,
                PromisedDate = request.PromisedDate,
                Status = OrderStatus.Pending,
                PaymentType = type,
                Total = orderItems.Sum(x => x.Price * x.Quantity),
                OrderItems = orderItems
            };

            Context.Orders.Add(newOrder);

            Context.SaveChanges();

            var user = Context.Users.Find(_actor.Id);

            //var smtpClient = new SmtpClient("smtp.gmail.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential("admin123", "sifra123"),
            //    EnableSsl = true,
            //};

            //smtpClient.Send("korma2001mt@gmail.com", user.Email, "Porudzbina - SneakersShop", $"Vasa porudzbina je potvrdjena. Broj porudzbine je {newOrder.Id}");
        }
    }
}
