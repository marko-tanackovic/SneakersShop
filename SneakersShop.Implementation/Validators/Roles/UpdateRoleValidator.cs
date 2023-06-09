using FluentValidation;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Validators
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDTO>
    {
        public UpdateRoleValidator(SneakersShopContext context)
        {
            RuleFor(x => x.RoleId).NotNull()
                                  .WithMessage("Role is required")
                                  .Must(x => context.Roles.Any(s => s.Id == x))
                                  .WithMessage("Role doesn't exist");
        }
    }
}
