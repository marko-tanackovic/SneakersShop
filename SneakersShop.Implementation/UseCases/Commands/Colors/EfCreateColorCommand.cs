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
    public class EfCreateColorCommand : EfUseCase, ICreateColorCommand
    {
        private readonly CreateColorValidator _validator;
        public EfCreateColorCommand(SneakersShopContext context, CreateColorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create Color";

        public string Description => "";

        public void Execute(CreateSizeCategoryBrandColorDTO request)
        {
            _validator.ValidateAndThrow(request);

            var newColor = new Color
            {
                Name = request.Name
            };

            Context.Colors.Add(newColor);

            Context.SaveChanges();
        }
    }
}
