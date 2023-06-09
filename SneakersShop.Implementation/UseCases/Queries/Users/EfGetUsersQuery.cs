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
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Get Users";

        public string Description => "Get users with search";

        public IEnumerable<UserDTO> Execute(UserSearch search)
        {
            var query = Context.Users.Include(x => x.Role)
                                     .Include(x => x.Orders)
                                     .Include(x => x.Reviews)
                                     .Include(x => x.City)
                                     .Include(x => x.ProfileImage)
                                     .Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                search.Keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Username.ToLower().Contains(search.Keyword) ||
                                         x.FirstName.ToLower().Contains(search.Keyword) ||
                                         x.LastName.ToLower().Contains(search.Keyword) ||
                                         x.Role.Name.ToLower().Contains(search.Keyword));
            }

            if (search.HasReviews.HasValue)
            {
                query = query.Where(x => x.Reviews.Any() == search.HasReviews.Value);
            }

            if (search.Orders.HasValue)
            {
                query = query.Where(x => x.Orders.Count() >= search.Orders.Value);
            }

            var users = query.Select(x => new UserDTO
            {
                Id = x.Id,
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                BirthDate = x.BirthDate.Value,
                Address = x.Address,
                City = x.City.Name,
                ZipCode = x.City.ZipCode,
                Phone = x.Phone,
                Role = x.Role.Name,
                Image = x.ProfileImage.Path
            }).ToList();

            return users;
        }
    }
}
