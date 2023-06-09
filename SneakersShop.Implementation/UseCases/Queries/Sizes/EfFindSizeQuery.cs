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
    public class EfFindSizeQuery : EfUseCase, IFindSizeQuery
    {
        public EfFindSizeQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Find Size";

        public string Description => "";

        public SizeDTO Execute(int search)
        {
            var size = Context.Sizes.Include(x => x.SizeCategory)
                                     .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (size == null)
            {
                throw new EntityNotFoundException(search, nameof(Size));
            }

            return (new SizeDTO
            {
                Id = size.Id,
                Number = size.Number,
                Detail = size.Detail,
                SizeCategory = size.SizeCategory.Name
            });
        }
    }
}
