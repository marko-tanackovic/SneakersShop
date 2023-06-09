using SneakersShop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakersShop.API.Jwt
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Email => "";

        public string Username => "unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 44, 3 };
    }
}
