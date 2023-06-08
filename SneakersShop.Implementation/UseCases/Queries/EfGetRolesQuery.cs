using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfGetRolesQuery : EfUseCase, IGetRolesQuery
    {
        public EfGetRolesQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 52;

        public string Name => "Get Roles";

        public string Description => "Get roles";

        public IEnumerable<RoleDTO> Execute(KeywordSearch search)
        {
            var query = Context.Roles.Include(x => x.RoleUseCases)
                                     .Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword));
            }

            var roles = query.Select(x => new RoleDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return roles;
        }
    }
}
