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
    public class EfDeleteProductCommand : EfUseCase, IDeleteProductCommand
    {
        public EfDeleteProductCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Delete Product";

        public string Description => "";

        public void Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null || !product.IsActive || product.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Product));
            }

            product.DeletedAt = DateTime.UtcNow;
            product.IsActive = false;

            Context.SaveChanges();
        }
    }
}
