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
    public class EfDeleteSizeCommand : EfUseCase, IDeleteSizeCommand
    {
        public EfDeleteSizeCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Delete Size";

        public string Description => "";

        public void Execute(int request)
        {
            var size = Context.Sizes.FirstOrDefault(s => s.Id == request);

            if (size == null || !size.IsActive || size.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Size));
            }

            size.DeletedAt = DateTime.UtcNow;
            size.IsActive = false;

            Context.SaveChanges();
        }
    }
}
