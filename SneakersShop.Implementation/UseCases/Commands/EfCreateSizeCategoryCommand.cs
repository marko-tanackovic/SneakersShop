using FluentValidation;
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
    public class EfCreateSizeCategoryCommand : EfUseCase, ICreateSizeCategoryCommand
    {
        private readonly CreateSizeCategoryValidator _validator;
        public EfCreateSizeCategoryCommand(SneakersShopContext context, CreateSizeCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Create Size Category";

        public string Description => "";

        public void Execute(CreateSizeCategoryBrandColorDTO request)
        {
            _validator.ValidateAndThrow(request);

            var newSCategory = new SizeCategory
            {
                Name = request.Name
            };

            Context.SizeCategories.Add(newSCategory);

            Context.SaveChanges();
        }
    }
}
