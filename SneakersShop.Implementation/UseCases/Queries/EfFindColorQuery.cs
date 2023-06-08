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
    public class EfFindColorQuery : EfUseCase, IFindColorQuery
    {
        public EfFindColorQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Find Color";

        public string Description => "";

        public BrandColorDTO Execute(int search)
        {
            var color = Context.Colors.Include(x => x.ColorProducts).FirstOrDefault(x => x.Id == search && x.IsActive);

            if (color == null)
            {
                throw new EntityNotFoundException(search, nameof(Color));
            }

            return (new BrandColorDTO
            {
                Id = color.Id,
                Name = color.Name,
                Products = color.ColorProducts.Count()
            });
        }
    }
}
