using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCaseHandling
{
    public class AuthorizationQueryHandler : IQueryHandler
    {
        private IApplicationActor _actor;
        private IQueryHandler _next;

        public AuthorizationQueryHandler(IApplicationActor actor, IQueryHandler next)
        {
            _actor = actor;

            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
            _next = next;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseAccessException(_actor.Username, query.Name);
            }

            return _next.HandleQuery(query, search);
        }
    }
}
