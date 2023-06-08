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
    public class EfFindUserQuery : EfUseCase, IFindUserQuery
    {
        public EfFindUserQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 42;

        public string Name => "Find User";

        public string Description => "Find user by id";

        public UserDTO Execute(int search)
        {
            var user = Context.Users.Include(x => x.Role)
                                     .Include(x => x.Orders)
                                     .Include(x => x.Reviews)
                                     .Include(x => x.City)
                                     .FirstOrDefault(x => x.Id == search && x.IsActive);

            if(user == null)
            {
                throw new EntityNotFoundException(search, nameof(User));
            }

            var result = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate.Value,
                Address = user.Address,
                City = user.City.Name,
                ZipCode = user.City.ZipCode,
                Phone = user.Phone,
                Role = user.Role.Name,
                Image = user.ProfileImage.Path
            };

            return result;
        }
    }
}
