using System;
using System.Collections.Generic;

namespace SneakersShop.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Email { get; }
        string Username { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
