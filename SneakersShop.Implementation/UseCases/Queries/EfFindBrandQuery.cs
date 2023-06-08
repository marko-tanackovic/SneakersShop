using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfFindBrandQuery : IFindBrandQuery
    {
        public int Id => 5;

        public string Name => "Find Brand";

        public string Description => "";

        private readonly SneakersShopContext _context;

        public EfFindBrandQuery(SneakersShopContext context)
        {
            _context = context;
        }

        public BrandColorDTO Execute(int search)
        {
            var brand = _context.Brands.Include(x => x.Products).FirstOrDefault(x => x.Id == search && x.IsActive);

            if (brand == null)
            {
                throw new EntityNotFoundException(search, nameof(Brand));
            }

            return(new BrandColorDTO
            {
                Id = brand.Id,
                Name = brand.Name,
                Products = brand.Products.Count()
            });
        }
    }
}
