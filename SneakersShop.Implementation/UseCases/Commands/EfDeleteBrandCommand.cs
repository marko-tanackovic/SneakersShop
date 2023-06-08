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
    public class EfDeleteBrandCommand : EfUseCase, IDeleteBrandCommand
    {
        public EfDeleteBrandCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Delete Brand";

        public string Description => "";

        public void Execute(int request)
        {
            var brand = Context.Brands.FirstOrDefault(b => b.Id == request);

            if (brand == null || !brand.IsActive || brand.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Brand));
            }

            brand.DeletedAt = DateTime.UtcNow;
            brand.IsActive = false;

            Context.SaveChanges();
        }
    }
}
