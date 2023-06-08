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
    public class EfDeleteSizeCategoryCommand : EfUseCase, IDeleteSizeCategoryCommand
    {
        public EfDeleteSizeCategoryCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Delete Size Category";

        public string Description => "";

        public void Execute(int request)
        {
            var sizeCategory = Context.SizeCategories.FirstOrDefault(sc => sc.Id == request);

            if (sizeCategory == null || !sizeCategory.IsActive || sizeCategory.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(SizeCategory));
            }

            sizeCategory.DeletedAt = DateTime.UtcNow;
            sizeCategory.IsActive = false;

            Context.SaveChanges();
        }
    }
}
