using FluentValidation;
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
    public class EfCreateProductSizeCommand : EfUseCase, ICreateProductSizeCommand
    {
        private readonly CreateProductSizeValidator _validator;
        public EfCreateProductSizeCommand(SneakersShopContext context,
                                          CreateProductSizeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 51;

        public string Name => "Create ProductSize";

        public string Description => "Create product ready for selling with validators";

        public void Execute(CreateProductSizeDTO request)
        {
            _validator.ValidateAndThrow(request);

            List<StoreProductSize> storeProductSizes = new List<StoreProductSize>();

            foreach(var store in request.ProductStores)
            {
                var add = new StoreProductSize
                {
                    StoreId = store.StoreId,
                    Quantity = store.Quantity
                };

                storeProductSizes.Add(add);
            }

            var productSize = new ProductSize
            {
                ProductId = request.ProductId,
                SizeId = request.SizeId,
                ProductSizeStores = storeProductSizes
            };

            Context.ProductSizes.Add(productSize);

            Context.SaveChanges();
        }
    }
}
