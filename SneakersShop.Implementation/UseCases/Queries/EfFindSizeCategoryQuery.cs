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
    public class EfFindSizeCategoryQuery : EfUseCase, IFindSizeCategoryQuery
    {
        public EfFindSizeCategoryQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Find Size Category";

        public string Description => "";

        public SizeCategoryDTO Execute(int search)
        {
            var sizeCategory = Context.SizeCategories.Include(x => x.Sizes)
                                                     .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (sizeCategory == null)
            {
                throw new EntityNotFoundException(search, nameof(SizeCategory));
            }

            return (new SizeCategoryDTO
            {
                Id = sizeCategory.Id,
                Name = sizeCategory.Name,
                Sizes = sizeCategory.Sizes.OrderBy(x => x.Number).Select(x => x.Number)
            });
        }
    }
}
