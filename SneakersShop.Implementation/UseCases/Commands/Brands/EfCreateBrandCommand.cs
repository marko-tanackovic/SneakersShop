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
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        public int Id => 6;

        public string Name => "Create Brand";

        public string Description => "";

        private readonly CreateBrandValidator _validator;
        private readonly SneakersShopContext _context;

        public EfCreateBrandCommand(CreateBrandValidator validator, SneakersShopContext context)
        {
            _validator = validator;
            _context = context;
        }

        public void Execute(CreateSizeCategoryBrandColorDTO request)
        {
            _validator.ValidateAndThrow(request);

            var newBrand = new Brand
            {
                Name = request.Name,
            };

            _context.Brands.Add(newBrand);

            _context.SaveChanges();
        }
    }
}
