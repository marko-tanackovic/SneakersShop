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
    public class EfUpdateSizeCategoryCommand : EfUseCase, IUpdateSizeCategoryCommand
    {
        private readonly UpdateSizeCategoryValidator _validator;
        public EfUpdateSizeCategoryCommand(SneakersShopContext context, UpdateSizeCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Update Size Category";

        public string Description => "Update size category using validator";

        public void Execute(UpdateSizeCategoryColorBrandDTO request)
        {
            var sCategory = Context.SizeCategories.FirstOrDefault(x => x.Id == request.Id);

            if (sCategory == null || !sCategory.IsActive || sCategory.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(SizeCategory));
            }

            _validator.ValidateAndThrow(request);

            sCategory.Name = request.Name;
            sCategory.ModifiedAt = DateTime.UtcNow;
            Context.Entry(sCategory).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
