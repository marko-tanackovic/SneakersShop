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
    public class EfCreateSizeCommand : EfUseCase, ICreateSizeCommand
    {
        private readonly CreateSizeValidator _validator;
        public EfCreateSizeCommand(SneakersShopContext context, CreateSizeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "Create Size";

        public string Description => "";

        public void Execute(CreateSizeDTO request)
        {
            _validator.ValidateAndThrow(request);

            var newSize = new Size
            {
                Number = request.Number,
                Detail = request.Detail,
                SizeCategoryId = request.SizeCategoryId
            };

            Context.Sizes.Add(newSize);

            Context.SaveChanges();
        }
    }
}
