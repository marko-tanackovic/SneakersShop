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
    public class EfDeleteColorCommand : EfUseCase, IDeleteColorCommand
    {
        public EfDeleteColorCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Delete Color";

        public string Description => "";

        public void Execute(int request)
        {
            var color = Context.Colors.FirstOrDefault(c => c.Id == request);

            if (color == null || !color.IsActive || color.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(Color));
            }

            color.DeletedAt = DateTime.UtcNow;
            color.IsActive = false;

            Context.SaveChanges();
        }
    }
}
