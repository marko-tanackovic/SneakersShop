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
    public class EfUpdateSizeCommand : EfUseCase, IUpdateSizeCommand
    {
        private readonly UpdateSizeValidator _validator;
        public EfUpdateSizeCommand(SneakersShopContext context, UpdateSizeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Update Size";

        public string Description => "Update size using validator";

        public void Execute(UpdateSizeDTO request)
        {
            var size = Context.Sizes.FirstOrDefault(x => x.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (size == null || !size.IsActive || size.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Size));
            }

            if (request.Number.HasValue)
            {
                size.Number = request.Number.Value;
            }

            size.Detail = request.Detail;
            size.ModifiedAt = DateTime.UtcNow;
            Context.Entry(size).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}
