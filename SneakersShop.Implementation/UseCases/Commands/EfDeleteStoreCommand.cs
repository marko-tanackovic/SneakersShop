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
    public class EfDeleteStoreCommand : EfUseCase, IDeleteStoreCommand
    {
        public EfDeleteStoreCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Delete Store";

        public string Description => "";

        public void Execute(int request)
        {
            var store = Context.Stores.Find(request);

            if (store == null || !store.IsActive || store.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Store));
            }

            store.DeletedAt = DateTime.UtcNow;
            store.IsActive = false;

            Context.SaveChanges();
        }
    }
}
