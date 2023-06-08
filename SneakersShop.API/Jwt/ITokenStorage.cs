using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakersShop.API.Jwt
{
    public interface ITokenStorage
    {
        void AddToken(string id);
        bool TokenExists(string id);
        void InvalidateToken(string id);
    }
}
