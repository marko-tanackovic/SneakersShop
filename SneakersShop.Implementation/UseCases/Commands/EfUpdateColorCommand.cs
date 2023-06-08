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
    public class EfUpdateColorCommand : EfUseCase, IUpdateColorCommand
    {
        private readonly UpdateColorValidator _validator;
        public EfUpdateColorCommand(SneakersShopContext context, UpdateColorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Update Color";

        public string Description => "Update color using validator";

        public void Execute(UpdateSizeCategoryColorBrandDTO request)
        {
            var color = Context.Colors.FirstOrDefault(x => x.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (color == null || !color.IsActive || color.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Color));
            }

            color.Name = request.Name;
            color.ModifiedAt = DateTime.UtcNow;
            Context.Entry(color).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
