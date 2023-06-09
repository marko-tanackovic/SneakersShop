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
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 43;

        public string Name => "Delete User";

        public string Description => "Delete user by id";

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null || !user.IsActive || user.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request, nameof(User));
            }

            user.DeletedAt = DateTime.UtcNow;
            user.IsActive = false;

            Context.SaveChanges();
        }
    }
}
