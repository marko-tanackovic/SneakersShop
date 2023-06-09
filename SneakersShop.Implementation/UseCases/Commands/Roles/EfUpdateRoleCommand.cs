using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
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
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        private readonly UpdateRoleValidator _validator;
        public EfUpdateRoleCommand(SneakersShopContext context, 
                                   UpdateRoleValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 55;

        public string Name => "Update Role";

        public string Description => "Update role for users";

        public void Execute(UpdateRoleDTO request)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == request.Id);

            if (user == null || !user.IsActive || user.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(User));
            }

            _validator.ValidateAndThrow(request);

            user.RoleId = request.RoleId;
            user.ModifiedAt = DateTime.UtcNow;
            Context.Entry(user).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
